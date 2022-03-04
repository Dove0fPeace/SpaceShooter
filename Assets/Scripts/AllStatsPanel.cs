using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpaceShooter
{
    public class AllStatsPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_Kills;
        [SerializeField] private TMP_Text m_Score;
        [SerializeField] private TMP_Text m_Time;

        public void ShowStats()
        {
            m_Kills.text = "All Kills : " + PlayerPrefs.GetInt("All kills").ToString();
            m_Score.text = "All Score : " + PlayerPrefs.GetInt("Score").ToString();
            m_Time.text = "All Time : " + PlayerPrefs.GetInt("All time").ToString();
        }

        public void OnButtonBack()
        {
            gameObject.SetActive(false);
        }
    }
}