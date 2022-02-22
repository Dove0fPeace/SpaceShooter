using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class GateTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject m_Text;
        [SerializeField] private GameObject m_Gate;

        private bool _sphereFound = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            m_Text.SetActive(true);
            if(_sphereFound)
            {
                m_Text.SetActive(false);
                m_Gate.SetActive(false);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            m_Text.SetActive(false);
        }
        public void TakeSphere()
        {
            _sphereFound = true;
        }
    }
}