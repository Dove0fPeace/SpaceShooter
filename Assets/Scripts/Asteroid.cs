using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : Destructible
    {
        [SerializeField] private Destructible[] m_SmallAsteroid;
        public Destructible[] SmallAsteroid => m_SmallAsteroid;

        [SerializeField] private float m_Speed;
        public float Speed => m_Speed;

        [SerializeField] private int m_SmallAsteroidsNum;
        public int SmallAsteroidsNum => m_SmallAsteroidsNum;


        protected override void OnDeath(bool playersProjectile)
        {
            for (int i = 0; i < m_SmallAsteroidsNum; i++)
            {
                Vector2 pos = this.transform.position;
                pos += Random.insideUnitCircle * 0.5f;

                int index = Random.Range(0, m_SmallAsteroid.Length);
                GameObject asteroid = Instantiate(m_SmallAsteroid[index].gameObject, pos, this.transform.rotation);

                asteroid.GetComponent<Asteroid>().SetTrajectory(Random.insideUnitCircle.normalized);
            }
            Player.Instance.AddScore(ScoreValue);
            base.OnDeath(playersProjectile);
        }

        private void SetTrajectory(Vector2 direction)
        {
            if (m_Speed <= 0) return;

            this.GetComponent<Rigidbody2D>().velocity = direction * m_Speed;
        }


    }
}