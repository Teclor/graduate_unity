using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeatThis.Game
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] private string MenuSceneName;
        [SerializeField] private string GameSceneName;
        [SerializeField] private string GameOverSceneName;

        public void LoadMenuScene()
        {
            SceneManager.LoadScene(MenuSceneName);
        }

        public void LoadMainGameScene()
        {
            SceneManager.LoadScene(GameSceneName);
        }

        public void LoadGameOverScene()
        {
            SceneManager.LoadScene(GameOverSceneName);
        }

        public void QuitApp()
        {
            Application.Quit();
        }
    }
}