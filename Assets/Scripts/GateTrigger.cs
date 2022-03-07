using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class GateTrigger : MonoBehaviour
    {
        [SerializeField] private UserHelpPanel m_Text;
        [SerializeField] private GameObject m_Gate;
        [SerializeField] private string m_HelpText;

        [SerializeField] private bool m_IsTrigger;

        private bool _sphereFound = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SpaceShip ship = collision.transform.root.GetComponent<SpaceShip>();
            if (ship == null) return;
            if (ship.IsPlayersShip == false) return;

            m_Text.ShowHelpText(m_HelpText);
            if(_sphereFound && m_IsTrigger)
            {
                m_Text.HideHelpText();
                m_Gate.SetActive(false);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            m_Text.HideHelpText();
        }
        public void TakeSphere()
        {
            _sphereFound = true;
        }

        public void DeleteTrigger()
        {
            m_Text.HideHelpText();
            gameObject.SetActive(false);
        }
    }
}