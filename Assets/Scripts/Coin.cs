using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class Coin : MonoBehaviour
    {
        [SerializeField] private int m_Cost;
        [SerializeField] private Player player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player") )
            {
                player.AddCoin(m_Cost);
                Destroy(gameObject);
            }
        }
    }
}