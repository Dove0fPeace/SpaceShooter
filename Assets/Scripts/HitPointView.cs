using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpaceShooter
{

    public class HitPointView : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_HPText;
        private SpaceShip m_TargetShip;

        public void SetTargetShip(SpaceShip ship)
        {
            m_TargetShip = ship;
        }

        private void Update()
        {
            ShowCurrentHP(m_TargetShip.CurrentHP, m_TargetShip.HP);
        }

        public void ShowCurrentHP(int currentHP, int maxHP)
        {
            m_HPText.text = "HitPoint: " + currentHP.ToString() + "/" + maxHP.ToString();
        }
    }
}