using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class HitPointView : MonoBehaviour
    {
        [SerializeField] private Image m_Mask;
        [SerializeField] private Destructible m_Target;

        private float m_OriginalSize;

        private void Start()
        {
            m_OriginalSize = m_Mask.rectTransform.rect.width;
        }

        public void SetTargetShip(SpaceShip ship)
        {
            m_Target = ship;
        }

        private void Update()
        {
            if (m_Target == null) return;

            ShowCurrentHP((float)m_Target.CurrentHP/ (float)m_Target.HP);
        }

        public void ShowCurrentHP(float value)
        {
            m_Mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_OriginalSize * value);
        }
    }
}