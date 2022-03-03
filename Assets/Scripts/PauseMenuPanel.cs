using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{

    public class PauseMenuPanel : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnButtonShowPause()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public void OnButtonContinue()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        public void OnButtonMainMenu()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);

            SceneManager.LoadScene(LevelSequenceController.MainMenuSceneNickname);
        }
    }
}