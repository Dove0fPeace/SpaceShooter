using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceShooter
{

    public class ShipSelectionController : MonoBehaviour
    {
        [SerializeField] private SpaceShip m_ShipPrefab;

        [SerializeField] private TMP_Text m_ShipName;
        [SerializeField] private TMP_Text m_HitPoints;
        [SerializeField] private TMP_Text m_Speed;
        [SerializeField] private TMP_Text m_Agility;

        [SerializeField] private Image m_Preview;

        private void Start()
        {
            m_ShipName.text = m_ShipPrefab.Nickname;
            m_HitPoints.text = m_ShipPrefab.HP.ToString();
            m_Speed.text = m_ShipPrefab.MaxLinearVelocity.ToString();
            m_Agility.text = m_ShipPrefab.MaxAngularVelocity.ToString();

            m_Preview.sprite = m_ShipPrefab.ShipPreview;
        }

        public void OnSelectShip()
        {
            LevelSequenceController.PlayerShip = m_ShipPrefab;

            MainMenuController.Instance.gameObject.SetActive(true);
        }
    }
}