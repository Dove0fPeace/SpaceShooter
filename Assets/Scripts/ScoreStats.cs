using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpaceShooter
{
    public class ScoreStats : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_Text;

        private int m_LastScore;

        private void Update()
        {
            UpdateScore();
        }

        private void UpdateScore()
        {
            if(Player.Instance != null)
            {
                float currentScore = Player.Instance.Score;

                if (m_LastScore != currentScore)
                {
                    m_LastScore = (int)currentScore;

                    m_Text.text = "Score : " + m_LastScore.ToString();
                }
            }
        }
    }
}