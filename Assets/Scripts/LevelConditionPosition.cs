using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpaceShooter
{

    public class LevelConditionPosition : LevelConditionBase, ILevelCondition
    {
        private bool m_Complete;

        private void Start()
        {
            LevelGoalsView.Instance?.AddLevelConditions(this);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.root.GetComponent<SpaceShip>().IsPlayersShip == true)
            {
                m_Complete = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.root.GetComponent<SpaceShip>().IsPlayersShip == true)
            {
                m_Complete = false;
            }
        }

        public override TextMeshProUGUI ConditionText()
        {
            m_Goal.text = "   Move to Finish Area " + "<br>";
            return m_Goal;
        }

        bool ILevelCondition.IsCompleted
        {
            get
            {
                return m_Complete;
            }
        }
    }
}