using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionRace : LevelConditionBase
    {
        [SerializeField] private int m_Laps;
        [SerializeField] private RaceLine m_FinishLine;
        private RaceLine[] m_Racelines;

        private int m_CheckLines;

        private void Start()
        {
            m_Racelines = GetComponentsInChildren<RaceLine>();
            m_CheckLines = m_Racelines.Length * m_Laps;
        }

        public void CheckLine(RaceLine nextCheck)
        {
            nextCheck.ActivateLine();
            m_CheckLines--;

            if(m_CheckLines == 1)
            {
                m_FinishLine.SetFinishLine();
            }
        }

    }
}