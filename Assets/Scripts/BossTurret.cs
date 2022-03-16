using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class BossTurret : MonoBehaviour
    {
        [SerializeField] private TurretProperties m_TurretProps;

        public void Fire()
        {
            if (m_TurretProps == null) return;

            Projectile projectile = Instantiate(m_TurretProps.ProgectilePrefab).GetComponent<Projectile>();
            projectile.IsPlayerProjectile = false;
            projectile.transform.position = transform.position;
            projectile.transform.up = transform.up;
        }
    }
}