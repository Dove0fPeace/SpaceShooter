using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class BigBoom : ImpactEffect
    {
        [SerializeField] private int m_Damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destructible dest = collision.transform.root.GetComponent<Destructible>();
            if (dest != null)
                dest.ApplyDamage(m_Damage);
        }
    }
}