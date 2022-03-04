using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class LevelConditionPosition : MonoBehaviour, ILevelCondition
    {
        private bool m_Complete;
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

        bool ILevelCondition.IsCompleted
        {
            get
            {
                return m_Complete;
            }
        }
    }
}