using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class MovementController : MonoBehaviour
    {
        public enum ControlMode
        {
            Keyboard,
            Mobile
        }

        [SerializeField] private SpaceShip m_TargetShip;
        public void SetTargetShip(SpaceShip ship) => m_TargetShip = ship;

        [SerializeField] private FloatingJoystick m_VirtualJoystick;

        [SerializeField] private PointerClickHold m_MobileFirePrimary;
        [SerializeField] private PointerClickHold m_MobileFireSecondary;

        [SerializeField] private ControlMode m_ControlMode;

        private void Start()
        {
            if(m_ControlMode == ControlMode.Keyboard)
            {
                m_MobileFirePrimary.gameObject.SetActive(false);
                m_MobileFireSecondary.gameObject.SetActive(false);
            }
            if(m_ControlMode == ControlMode.Mobile)
            {
                m_MobileFirePrimary.gameObject.SetActive(true);
                m_MobileFireSecondary.gameObject.SetActive(true);
            }
        }
        private void Update()
        {
            if (m_TargetShip == null) return;

            Vector2 dir = m_VirtualJoystick.Direction;

            if (Input.GetAxis("Horizontal") != 0 | Input.GetAxis("Vertical") != 0)
            {
                dir.x = Input.GetAxis("Horizontal");
                dir.y = Input.GetAxis("Vertical");
            }

            var dot = Vector2.Dot(dir, m_TargetShip.transform.up);
            var dot2 = Vector2.Dot(dir, m_TargetShip.transform.right);

            m_TargetShip.TrustControl = Mathf.Max(0, dot);
            m_TargetShip.TorqueControl = dot2;

            if(m_ControlMode == ControlMode.Keyboard)
            {
                KeyboardControl();
            }

            if(m_ControlMode == ControlMode.Mobile)
            {
                MobileControl();
            }
        }

        private void KeyboardControl()
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                m_TargetShip.Fire(TurretMode.Primary);
            }

            if (Input.GetAxis("Fire2") != 0)
            {
                m_TargetShip.Fire(TurretMode.Secondary);
            }
        }

        private void MobileControl()
        {
            if (m_MobileFirePrimary.IsHold == true)
            {
                m_TargetShip.Fire(TurretMode.Primary);
            }

            if (m_MobileFireSecondary.IsHold == true)
            {
                m_TargetShip.Fire(TurretMode.Secondary);
            }
        }
    }
}