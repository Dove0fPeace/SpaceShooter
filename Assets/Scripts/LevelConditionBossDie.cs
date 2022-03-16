using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class LevelConditionBossDie : LevelConditionBase, ILevelCondition
    {
        private bool m_Reached;
        [SerializeField] private Boss m_Boss;
        [SerializeField] private UnityEvent m_ScoreConditionComplete;
        public UnityEvent ScoreConditionComplete => m_ScoreConditionComplete;
        void Start()
        {
            LevelGoalsView.Instance?.AddLevelConditions(this);
            m_Boss.EventOnDeath.AddListener(BossDie);
        }
        bool ILevelCondition.IsCompleted
        {
            get
            {
                return m_Reached;
            }
        }

        private void BossDie()
        {
            m_Reached = true;
        }
    }
}