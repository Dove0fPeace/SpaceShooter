using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class ViewEnergy : MonoBehaviour
    {
        [SerializeField] private Image m_Mask;
        private float m_OriginalSize;

        private SpaceShip m_TargetShip;

        private void Start()
        {
            m_OriginalSize = m_Mask.rectTransform.rect.width;
        }
        public void SetTargetShip(SpaceShip ship)
        {
            m_TargetShip = ship;
        }

        private void Update()
        {
            SetValue(m_TargetShip.Energy / m_TargetShip.MaxEnergy);
        }

        private void SetValue(float value)
        {
            m_Mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_OriginalSize * value);
        }
    }
}