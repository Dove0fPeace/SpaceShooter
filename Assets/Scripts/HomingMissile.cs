using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class HomingMissile : Projectile
    {
        [SerializeField] private CircleArea m_Area;
        [SerializeField] private float m_RotateSpeed;

        private Rigidbody2D rb;

        private GameObject m_Target;


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            m_Target = FindClosestByTag("Enemy");
        }

        protected override void FixedUpdate()
        {
            if (m_Target != null)
            {
                Vector2 direction = (Vector2)m_Target.transform.position - rb.position;
                direction.Normalize();

                float rotateAmount = Vector3.Cross(direction, transform.up).z;

                rb.angularVelocity = -rotateAmount * m_RotateSpeed;

                rb.velocity = transform.up * m_Velocity;

                m_Timer += Time.deltaTime;
                if (m_Timer > m_Lifetime)
                    Destroy(gameObject);
            }
            else
            {
                base.FixedUpdate();
            }
        }

        GameObject FindClosestByTag(string tag)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag(tag);
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
        }
    }
}