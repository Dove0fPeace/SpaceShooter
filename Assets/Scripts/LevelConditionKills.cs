using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class LevelConditionKills : LevelConditionBase, ILevelCondition
    {
        private bool m_Reached;
        [SerializeField] private UnityEvent m_ScoreConditionComplete;
        public UnityEvent ScoreConditionComplete => m_ScoreConditionComplete;
        void Start()
        {
            LevelGoalsView.Instance?.AddLevelConditions(this);
        }
        bool ILevelCondition.IsCompleted
        {
            get
            {
                if (Player.Instance != null && Player.Instance.ActiveShip != null)
                {

                    if (Destructible.Enemies.Count == 0)
                    {
                        m_Reached = true;
                        m_ScoreConditionComplete?.Invoke();
                    }
                }
                return m_Reached;
            }
        }
    }
}