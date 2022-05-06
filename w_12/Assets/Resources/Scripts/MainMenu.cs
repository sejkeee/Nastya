using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace w_12
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame() => SceneManager.LoadScene(1);
        public void Options(GameObject window) => window.SetActive(true);
        public void Quit() => Application.Quit();
    }
}

