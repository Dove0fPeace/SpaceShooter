using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class Collectibles : MonoBehaviour
    {
        [SerializeField] private LevelConditionCollect m_Condition;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.transform.tag == "Player")
            {
                m_Condition.AddCollect();
                Destroy(gameObject);
            }
        }
    }
}