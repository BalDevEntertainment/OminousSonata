using System;
using Domain.InteractuableEntity;
using Presentation.Pickups;

namespace Domain
{
    public interface IPlayerStatusController
    {
        void OnReceiveDamage(int damageAmount);
    }
}