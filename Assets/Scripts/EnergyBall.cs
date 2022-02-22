using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class EnergyBall : MonoBehaviour
    {
        [SerializeField] private GateTrigger m_Trigger;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            m_Trigger.TakeSphere();
            Destroy(gameObject);
        }
    }
}