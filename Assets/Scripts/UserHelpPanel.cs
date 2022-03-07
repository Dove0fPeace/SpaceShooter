using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{

    public class UserHelpPanel : MonoBehaviour
    {
        [SerializeField] private Text m_text;

        public void ShowHelpText (string text)
        {
            m_text.text = text;
            gameObject.SetActive(true);
        }

        public void HideHelpText()
        {
            gameObject.SetActive(false);
        }
    }
}