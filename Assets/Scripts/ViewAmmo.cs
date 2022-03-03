using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpaceShooter
{
    public class ViewAmmo : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_Ammo;
        private SpaceShip m_TargetShip;

        public void SetTargetShip(SpaceShip ship)
        {
            m_TargetShip = ship;
        }

        private void Update()
        {
            ShowCurrentAmmo();
        }

        private void ShowCurrentAmmo()
        {
            m_Ammo.text = m_TargetShip.Ammo.ToString();
        }
    }
}