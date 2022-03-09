using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace SpaceShooter
{

    public class LevelConditionScore : LevelConditionBase, ILevelCondition
    {
        [SerializeField] private int m_Score;
        private TextMeshProUGUI m_ScoreText;
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
                if(Player.Instance != null && Player.Instance.ActiveShip != null)
                {

                    if(Player.Instance.Score >= m_Score)
                    {
                        m_Reached = true;
                        m_ScoreConditionComplete?.Invoke();
                    }
                }
                return m_Reached;
            }
        }

        public override TextMeshProUGUI ConditionText()
        {
            Debug.Log("ConditionScoreText");
            m_ScoreText.text = "   Score 0" + "/" + m_Score.ToString() + "<br>";
            return m_ScoreText;
        }
    }
}