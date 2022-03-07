using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{

    public class EnergyBallGate : MonoBehaviour
    {
        private Asteroid[] m_Asteroids;
        [SerializeField] private LevelConditionScore m_LevelConditionScore;
        [SerializeField] private GateTrigger m_GateTrigger;

        [SerializeField] private GameObject m_ExplisionPrefab;
        void Start()
        {
            m_Asteroids = GetComponentsInChildren<Asteroid>();
            m_LevelConditionScore.ScoreConditionComplete.AddListener(DestroyAsteroids);
        }

        private void DestroyAsteroids()
        {
            m_GateTrigger.DeleteTrigger();

            foreach(var v in m_Asteroids)
            {
                if (v != null)
                {
                    var explode = Instantiate(m_ExplisionPrefab, v.transform);
                    v.ExplodeAsteroid();
                }
            }
        }
    }
}