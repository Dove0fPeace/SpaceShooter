using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class BossWaypoints : MonoBehaviour
    {
        [SerializeField] private Boss Boss;

        private Waypoint[] waypoints;

        private void Start()
        {
            waypoints = GetComponentsInChildren<Waypoint>();
            Boss.SetWaypoints(waypoints);
        }
    }
}