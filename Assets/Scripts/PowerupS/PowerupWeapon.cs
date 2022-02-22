using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class PowerupWeapon : Powerup
    {

        [SerializeField] private TurretProperties m_Properties;

        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.AssignWeapon(m_Properties);
            if (m_Properties.Mode == TurretMode.Primary)
                ship.AddEnergy(ship.MaxEnergy);
            if (m_Properties.Mode == TurretMode.Secondary)
                ship.AddAmmo(ship.MaxAmmo);
                

        }
    }
}