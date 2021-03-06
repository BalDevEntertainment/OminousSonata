﻿#if PHOTON_BOLT
using UdpKit;
using UnityEngine;
using System.Collections;

namespace ICode.Actions.PhotonBolt{
	[Category("Photon Bolt")]    
	[Tooltip("Start the server.")]
	[System.Serializable]
	public class StartServer : StateAction {
		[DefaultValueAttribute("127.0.0.1")]
		public FsmString host;
		[DefaultValueAttribute(27000)]
		public FsmInt port;


		public override void OnEnter ()
		{
			UdpEndPoint endpoint = new UdpEndPoint(UdpIPv4Address.Parse(host.Value), (ushort)port.Value);
			BoltLauncher.StartServer(endpoint);
			Finish ();
		}
		
	}
}
#endif