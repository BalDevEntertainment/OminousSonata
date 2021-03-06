﻿using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ICode;
using ICode.Actions;
using Unitycoding;

namespace ICode.FSMEditor{
	public static class ErrorChecker  {
		private static readonly List<FsmError> errorList;
		private static bool checkForErrors=true;

		static ErrorChecker(){
			ErrorChecker.errorList = new List<FsmError> ();
			EditorApplication.update += Update;
		}

		public static void CheckForErrors(){
			ClearErrors ();
			checkForErrors = true;
		}

		private static StateMachine checkingStateMachine;
		private static State checkingState;
		private static ExecutableNode checkingExecutableNode;

		public static void CheckForErrors(UnityEngine.Object targetObject){
			if (targetObject == null) {
				return;
			}
			if (targetObject.GetType ()==typeof(StateMachine)) {
				checkingStateMachine = targetObject as StateMachine;	
			}else if(targetObject.GetType()==typeof(State)){
				checkingState=targetObject as State;
			} else if (targetObject.GetType ().IsSubclassOf (typeof(ExecutableNode))) {
				checkingExecutableNode=targetObject as ExecutableNode;			
			}

			string obsoleteMessage = targetObject.GetObsoleteMessage ();
			if (!string.IsNullOrEmpty (obsoleteMessage)) {
				FsmError error=new FsmError(FsmError.ErrorType.Obsolete,checkingStateMachine,checkingState,checkingExecutableNode,null,null);
				if(!ContainsError(error)){
					errorList.Add(error);
				}
			}

			FieldInfo[] fields = targetObject.GetType().GetAllFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			for (int i=0; i<fields.Length; i++) {
				FieldInfo field=fields[i];
				if(field.HasAttribute(typeof(ReferenceAttribute)) || !field.IsSerialized()){
					continue;
				}
				object value=field.GetValue(targetObject);
				if(field.FieldType.IsSubclassOf(typeof(FsmVariable))){
					if(!field.HasAttribute(typeof(NotRequiredAttribute)) &&(value == null || CheckForVariableError(value as FsmVariable,field))){
						FsmError error=new FsmError(FsmError.ErrorType.RequiredField,checkingStateMachine,checkingState,checkingExecutableNode,value as FsmVariable,field);
						if(!ContainsError(error)){
							errorList.Add(error);
						}
					}
				}else if(field.FieldType.IsSubclassOf(typeof(UnityEngine.Object))){
					CheckForErrors(value as UnityEngine.Object);
				}else if(field.FieldType.IsArray){
					var array = value as Array;
					Type elementType = field.FieldType.GetElementType ();
					if(elementType.IsSubclassOf(typeof(UnityEngine.Object))){
						foreach(UnityEngine.Object element in array){
							CheckForErrors(element);
						}
					}
				}
			}
			checkForErrors = false;
		}



		public static bool HasErrors(UnityEngine.Object targetObject){
			return GetError (targetObject) != null;
		}

		public static FsmError GetError(UnityEngine.Object targetObject){
			foreach (FsmError mError in errorList) {
				if(mError.Variable == targetObject ||
				   mError.State == targetObject || 
				   mError.ExecutableNode == targetObject ||
				   mError.StateMachine == targetObject){
					return mError;
				}			
			}	
			return null;
		}

		public static void ClearErrors(){
			errorList.Clear ();		
		}

		private static bool CheckForVariableError(FsmVariable variable, FieldInfo field){
			if (variable.IsShared) {
				return variable.Name == "None" || string.IsNullOrEmpty(variable.Name);			
			} else {
				if(variable is FsmString){
					return CheckForStringError(((FsmString)variable).Value,field);
				}
			}
			return false;	
		}

		private static bool CheckForStringError(string value, FieldInfo field){
			if(field.HasAttribute(typeof(ComponentAttribute)) && !string.IsNullOrEmpty(value)){
				return TypeUtility.GetType(value)==null;
			}
			return string.IsNullOrEmpty(value);
		}

		private static bool ContainsError(FsmError error){
			foreach (FsmError mError in errorList) {
				if(mError.SameAs(error)){
					return true;
				}
			}	
			return false;
		}

		public static List<FsmError> GetErrors()
		{
			return ErrorChecker.errorList;
		}

		public static void Update(){
			if (checkForErrors) {
				StateMachine[] fsms= Resources.FindObjectsOfTypeAll<StateMachine>();
				for(int i=0;i<fsms.Length;i++){
					ErrorChecker.CheckForErrors(fsms[i]);	
				}
				FsmEditor.RepaintAll();
			}
		}

		private static StateMachine[] FindFsms(){
			StateMachine[] fsms = UnityEditorUtility.GetAssetsOfType<StateMachine> (".asset");
			ICodeBehaviour[] behaviours=UnityEditorUtility.FindInScene<ICodeBehaviour>().ToArray();
			fsms=ArrayUtility.AddRange<StateMachine>(fsms,behaviours.Where(x=>!EditorUtility.IsPersistent(x.stateMachine)).Select(y=>y.stateMachine).ToArray());
			return fsms;
		}


	}
}