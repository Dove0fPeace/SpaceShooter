using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class PU_Speed : Powerup
    {
        [SerializeField] private float m_Time;
        [SerializeField] private float m_Velocity;

        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.SpeedBust(m_Velocity, m_Time);
        }
    }
}