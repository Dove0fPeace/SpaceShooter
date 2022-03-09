using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class LevelConditionCollect : LevelConditionBase, ILevelCondition
    {
        [SerializeField] private int m_CollectionTarget;
        private int m_Collected;

        [SerializeField] private UnityEvent m_ScoreConditionComplete;
        public UnityEvent ScoreConditionComplete => m_ScoreConditionComplete;

        private bool m_Reached;

        private void Start()
        {
            LevelGoalsView.Instance?.AddLevelConditions(this);
        }

        bool ILevelCondition.IsCompleted
        {
            get
            {
                if (Player.Instance != null && Player.Instance.ActiveShip != null)
                {

                    if (m_Collected >= m_CollectionTarget)
                    {
                        m_Reached = true;
                        m_ScoreConditionComplete?.Invoke();
                    }
                }
                return m_Reached;
            }
        }

        public void AddCollect()
        {
            m_Collected++;
        }
    }
}