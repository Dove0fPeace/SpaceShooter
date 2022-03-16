using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{

    public class RaceLine : MonoBehaviour
    {
        private LevelConditionRace m_Race;
        [SerializeField] private RaceLine m_NextCheck;
        private bool m_FinishLine;
        private SpriteRenderer m_Sprite;
        private BoxCollider2D m_Collider;


        public void SetFinishLine()
        {
            m_FinishLine = true;
            m_Sprite.enabled = true;
        }

        public void ActivateLine()
        {
            m_Collider.enabled = true;
        }

        private void Start()
        {
            m_Race = GetComponentInParent<LevelConditionRace>();
            m_Sprite = GetComponent<SpriteRenderer>();
            m_Collider = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.root.GetComponent<SpaceShip>() == null) return;

            if(m_FinishLine)
            {
                bool PlayerWin = collision.transform.root.GetComponent<SpaceShip>().IsPlayersShip;
                FinishRace(PlayerWin);
            }
            m_Race.CheckLine(m_NextCheck);
            m_Collider.enabled = false;
        }

        private void FinishRace(bool player)
        {
            LevelSequenceController.Instance?.FinishCurrentLevel(player);
        }
    }
}