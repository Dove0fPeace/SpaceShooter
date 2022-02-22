using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class CollisionDamageApplicator : MonoBehaviour
    {
        public static string IgnoreTag = "WorldBoundary";
        public static string IgnoreTag2 = "Projectile";

        [SerializeField] private float m_VelocityDamageModifier;
        [SerializeField] private int m_DamageConstant;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == IgnoreTag || collision.transform.tag == IgnoreTag2) return;

            var destructible = transform.root.GetComponent<Destructible>();

            if(destructible != null )
            {
                destructible.ApplyDamage(m_DamageConstant + (int)(m_VelocityDamageModifier * collision.relativeVelocity.magnitude));
            }
        }
    }
}