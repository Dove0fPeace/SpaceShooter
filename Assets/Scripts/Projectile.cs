using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : Entity
    {
        [SerializeField] protected float m_Velocity;

        [SerializeField] protected float m_Lifetime;

        [SerializeField] private int m_Damage;

        [SerializeField] private GameObject m_Player;

        [SerializeField] private ImpactEffect m_ImpactEffectPrefab;


        protected float m_Timer;

        protected virtual void FixedUpdate()
        {
            float stepLenght = Time.deltaTime * m_Velocity;
            Vector2 step = transform.up * stepLenght;

            //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLenght);
            //if(hit)
            //{
            //    Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();
            //    if(dest != null && dest != m_Parent)
            //    {
            //        dest.ApplyDamage(m_Damage);
            //    }
            //    OnProjectileLifeEnd(hit.collider, hit.point);
            //}

            m_Timer += Time.deltaTime;
            if (m_Timer > m_Lifetime)
                OnProjectileLifeEnd();

            transform.position += new Vector3(step.x, step.y, 0);

        }

        private void OnProjectileLifeEnd()
        {
            ImpactEffect impact = Instantiate(m_ImpactEffectPrefab).GetComponent<ImpactEffect>();
            impact.transform.position = transform.position;
            impact.transform.up = transform.up;

            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destructible dest = collision.transform.root.GetComponent<Destructible>();
            if (dest != null)
            {
                dest.ApplyDamage(m_Damage);
                Player.Instance.AddScore(dest.ScoreValue);
            }
            OnProjectileLifeEnd();
        }
    }
}