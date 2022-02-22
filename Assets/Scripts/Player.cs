using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace SpaceShooter
{

    public class Player : SingletonBase<Player>
    {
        [SerializeField] private int m_NumLives;
        [SerializeField] private int m_Coins;
        public int CurrentCoins => m_Coins;
        [Space(10)]
        [SerializeField] private SpaceShip m_Ship;
        [SerializeField] private GameObject m_PlayerShipPrefab;
        public SpaceShip ActiveShip => m_Ship;
        [SerializeField] private GameObject m_ExplosionPrefab;

        [SerializeField] private CinemachineVirtualCamera vcam;
        [SerializeField] private MovementController m_MovementController;

        private Vector3 m_ExplosionPosition;
        private Quaternion m_ExplosionRotation;

        private void Start()
        {
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
            //vcam = GetComponent<CinemachineVirtualCamera>(); 
        }

        private void Update()
        {
            if (m_Ship != null)
            {
                m_ExplosionPosition = m_Ship.transform.position;
                m_ExplosionRotation = m_Ship.transform.rotation;
            }

        }
        private void OnShipDeath()
        {
            m_NumLives--;
            var Explode = Instantiate(m_ExplosionPrefab, m_ExplosionPosition, m_ExplosionRotation);

            if (m_NumLives > 0)
                Invoke("Respawn", 1);
            Debug.Log("resp");
        }

        private void Respawn()
        {
            var newPlayerShip = Instantiate(m_PlayerShipPrefab);
            m_Ship = newPlayerShip.GetComponent<SpaceShip>();
            m_Ship.EventOnDeath.AddListener(OnShipDeath);

            vcam.Follow = m_Ship.transform;
            m_MovementController.SetTargetShip(m_Ship);
        }

        public void AddCoin(int coin)
        {
            m_Coins += coin;
            Debug.Log(CurrentCoins);
        }

        #region Score

        public int Score { get; private set; }
        public int NumKills { get; private set; }

        public void AddKill()
        {
            NumKills++;
        }

        public void AddScore(int num)
        {
            Score += num;
            Debug.Log(Score);
        }

        #endregion
    }

}