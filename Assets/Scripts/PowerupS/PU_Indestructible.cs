using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class PU_Indestructible : Powerup
    {
        [SerializeField] private float m_Time;
        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.SetIndestructible(m_Time);
        }
    }
}