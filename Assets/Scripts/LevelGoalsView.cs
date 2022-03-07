using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpaceShooter
{
    public class LevelGoalsView : SingletonBase<LevelGoalsView>
    {
        [SerializeField] private TextMeshProUGUI m_GoalsText;

        [SerializeField] private List<LevelConditionBase> m_LevelConditions;

        private void Start()
        {
            m_GoalsText.text = "Level Goal: <br>";
        }
        private void Update()
        {
            ViewLevelGoals();
        }

        public void AddLevelConditions(LevelConditionBase conditions)
        {
            m_LevelConditions.Add(conditions);
        }
        
        private void ViewLevelGoals()
        {
            foreach (var v in m_LevelConditions)
            {
                m_GoalsText.text = m_GoalsText.text + v.ConditionText().text;
            }
        }
    }
}