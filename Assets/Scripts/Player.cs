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
        [Header("Recources view")]
        [SerializeField] private HitPointView m_HitPointView;
        [SerializeField] private ViewAmmo m_ViewAmmo;
        [SerializeField] private ViewEnergy m_ViewEnergy;

        private Vector3 m_ExplosionPosition;
        private Quaternion m_ExplosionRotation;

        protected override void Awake()
        {
            base.Awake();

            if(m_Ship != null)
                Destroy(m_Ship.gameObject);
        }
        private void Start()
        {
            Respawn();
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
            else
                LevelSequenceController.Instance?.FinishCurrentLevel(false);
        }

        private void Respawn()
        {
            if(LevelSequenceController.PlayerShip != null)
            {
                var newPlayerShip = Instantiate(LevelSequenceController.PlayerShip);
                m_Ship = newPlayerShip.GetComponent<SpaceShip>();
                m_Ship.EventOnDeath.AddListener(OnShipDeath);

                vcam.Follow = m_Ship.transform;

                m_HitPointView.SetTargetShip(m_Ship);
                m_MovementController.SetTargetShip(m_Ship);
                m_ViewAmmo.SetTargetShip(m_Ship);
                m_ViewEnergy.SetTargetShip(m_Ship);
            }
        }

        public void AddCoin(int coin)
        {
            m_Coins += coin;
        }

        #region Score

        public float Score { get; private set; }
        public int NumKills { get; private set; }

        public void AddKill()
        {
            NumKills++;
        }

        public void AddScore(float num)
        {
            Score += num;
        }

        #endregion
    }

}