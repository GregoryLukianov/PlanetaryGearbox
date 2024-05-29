using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts
{
    public class StartMenu: MonoBehaviour
    {
        public void LoadWorkScene()
        {
            SceneManager.LoadScene(1);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}