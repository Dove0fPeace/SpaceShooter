using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class RaceAITargetArea : MonoBehaviour
    {
        [SerializeField] private RaceAITargetArea m_NextArea;
        private CircleArea m_Area;

        public Vector2 GetRandonTargetPoint()
        {
            Vector2 TargetPoint = m_Area.GetRandomInsideZone();
            return TargetPoint;
        }

        private void Awake()
        {
            m_Area = GetComponent<CircleArea>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var ai = collision.transform.root.GetComponent<AIController>();
            if (ai != null)
            {
                ai.SetNextRaceTarget(m_NextArea.GetRandonTargetPoint());
            }
        }
    }
}