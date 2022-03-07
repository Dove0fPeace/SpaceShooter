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
        [SerializeField] private int m_NonLethalDamage;
        private int m_DamageConstant;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == IgnoreTag || collision.transform.tag == IgnoreTag2) return;

            bool player = false;
            if (collision.transform.root.GetComponent<SpaceShip>()?.IsPlayersShip == true)
                player = true;

            var destructible = transform.root.GetComponent<Destructible>();

            Asteroid asteroid = collision.transform.GetComponent<Asteroid>();

            if(asteroid != null)
            {
                m_DamageConstant = 9999;
            }
            else
            {
                m_DamageConstant = m_NonLethalDamage;
            }
            
            if(destructible != null )
            {
                destructible.ApplyDamage(m_DamageConstant + (int)(m_VelocityDamageModifier * collision.relativeVelocity.magnitude), player);
            }
        }
    }
}