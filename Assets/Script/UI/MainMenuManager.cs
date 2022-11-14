using UnityEngine;
using UnityEngine.SceneManagement;

namespace BulletRush
{
    public class MainMenuManager : MonoBehaviour
    {
        public void StartGame()
        {

            SceneManager.LoadScene(1);
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}
