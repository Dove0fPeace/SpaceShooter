using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MissileBase : Entity
    { 
        [SerializeField] private int m_Damage;

        [SerializeField] private float m_Speed;

        [SerializeField] private float m_Lifetime;

        [SerializeField] private ImpactEffect m_ImpactEffect;

        public bool IsPlayersRocket;

        private void Update()
        {
            m_Lifetime -= Time.deltaTime;
            if (m_Lifetime <= 0)
                OnMissileLifeEnd();
        }

        protected virtual void FixedUpdate()
        {
            float stepLenght = Time.fixedDeltaTime * m_Speed;
            Vector2 step = transform.up * stepLenght;

            transform.position = new Vector2(step.x, step.y);
        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            Destructible dest = collision.transform.root.GetComponent<Destructible>();
            if (dest != null)
                dest.ApplyDamage(m_Damage, IsPlayersRocket);
        }

        protected virtual void OnMissileLifeEnd()
        {
            ImpactEffect impact = Instantiate(m_ImpactEffect).GetComponent<ImpactEffect>();
            impact.transform.position = transform.position;
            impact.transform.up = transform.up;

            Destroy(gameObject);
    }
    }
}