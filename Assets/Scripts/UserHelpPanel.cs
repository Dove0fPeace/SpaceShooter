using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{

    public class UserHelpPanel : MonoBehaviour
    {
        [SerializeField] private Text m_text;
        [SerializeField] private GameObject m_TextPanel;

        [SerializeField] private float m_HideTime;
        private Timer m_HideTimer;

        private void Start()
        {
            m_HideTimer = new Timer(m_HideTime);
        }

        private void Update()
        {
            m_HideTimer.RemoveTime(Time.deltaTime);

            if(m_HideTimer.IsFinished)
            {
                HideHelpText();
            }
        }

        public void ShowHelpText (string text)
        {
            m_text.text = text;
            m_TextPanel.SetActive(true);
        }

        public void HideHelpText()
        {
            m_TextPanel.SetActive(false);
        }
    }
}