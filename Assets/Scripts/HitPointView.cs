using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class HitPointView : MonoBehaviour
    {
        [SerializeField] private Image m_Mask;
        private SpaceShip m_TargetShip;

        private float m_OriginalSize;

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
            ShowCurrentHP((float)m_TargetShip.CurrentHP/ (float)m_TargetShip.HP);
        }

        public void ShowCurrentHP(float value)
        {
            m_Mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_OriginalSize * value);
        }
    }
}