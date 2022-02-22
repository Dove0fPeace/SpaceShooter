using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{

    public class Portal : MonoBehaviour
    {
        [SerializeField] private string m_SceneName;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SceneManager.LoadScene(m_SceneName);
        }
    }
}