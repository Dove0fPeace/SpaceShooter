using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Boss : Destructible
    {
        [SerializeField] private BossTurret[] m_Turrets;
        [SerializeField] private Waypoint[] m_Waypoints;
        [SerializeField] private float m_MoveSpeed;
        [SerializeField] private float m_Mobility;

        private bool m_TouchWaypoint;

        private Waypoint m_NextWaypoint;

        [Space(5)]
        [SerializeField] private float m_ShootDelay;
        [SerializeField] private float m_SpawnShipsDelay;
        [SerializeField] private float m_SelectWaypointDelay;
        [SerializeField] private float m_TimeAllTurretsFire;

        private Destructible m_Ship;

        private Timer _FireTimer;
        private Timer _AllTurretsFireTimer;
        private Timer _SpavnShipTimer;
        private Timer _SelectWaypointDelay;

        #region TIMERS

        private void InitTimers()
        {
            _FireTimer = new Timer(m_ShootDelay);
            _AllTurretsFireTimer = new Timer(m_TimeAllTurretsFire);
            _SpavnShipTimer = new Timer(m_SpawnShipsDelay);
            _SelectWaypointDelay = new Timer(m_SelectWaypointDelay);
        }

        private void UpdateTimers()
        {
            _FireTimer.RemoveTime(Time.fixedDeltaTime);
            _AllTurretsFireTimer.RemoveTime(Time.fixedDeltaTime);
            _SpavnShipTimer.RemoveTime(Time.fixedDeltaTime);
            _SelectWaypointDelay.RemoveTime(Time.fixedDeltaTime);
        }

        #endregion

        protected override void Start()
        {
            base.Start();
            InitTimers();
            m_Turrets = GetComponentsInChildren<BossTurret>();
        }

        private void Update()
        {
            if(m_TouchWaypoint && _SelectWaypointDelay.IsFinished)
            {
                SelectWaypoint();
                _SelectWaypointDelay.Start(m_SelectWaypointDelay);
            }

            if(_FireTimer.IsFinished)
            {
                var index = Random.Range(0, m_Turrets.Length);
                BossTurret turret = m_Turrets[index];
                Fire(turret);
                _FireTimer.Start(m_ShootDelay);
            }

            if(_AllTurretsFireTimer.IsFinished)
            {
                FireAllTurrets();
                _AllTurretsFireTimer.Start(m_TimeAllTurretsFire);
            }
        }

        private void FixedUpdate()
        {
            Move();
            UpdateTimers();
            TurnToThePlayer();
        }

        public void SetWaypoints(Waypoint[] set)
        {
            m_Waypoints = set;
            SelectWaypoint();
        }
        public void SelectWaypoint()
        {
            m_NextWaypoint = m_Waypoints[Random.Range(0, m_Waypoints.Length)];
        }

        public void SetPlayerShip(Destructible ship)
        {
            m_Ship = ship;
        }

        private void Move()
        {
            float step = m_MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, m_NextWaypoint.transform.position, step);
        }

        private void TurnToThePlayer()
        {
            if (m_Ship == null) return;

            transform.up = (m_Ship.transform.position - transform.position).normalized;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.GetComponent<Waypoint>())
                m_TouchWaypoint = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.GetComponent<Waypoint>())
                m_TouchWaypoint = false;
        }

        private void Fire(BossTurret turret)
        {
            if (m_Ship == null)
            {
                turret.transform.up = transform.up;
            }
            else
            {
                var target = m_Ship.PositionPrediction();
                turret.transform.up = (target - turret.transform.position).normalized;
            }
            turret.Fire();
        }

        private void FireAllTurrets()
        {
            foreach(var v in m_Turrets)
            {
                Fire(v);
            }
        }
    }
}