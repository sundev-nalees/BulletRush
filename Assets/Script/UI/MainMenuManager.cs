using UnityEngine;
using UnityEngine.SceneManagement;

namespace BulletRush
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] AudioSource soundPlayer;
        

        public void StartGame()
        {

            SceneManager.LoadScene(1);
            soundPlayer.Play();
        }
        public void Quit()
        {
            Application.Quit();
            soundPlayer.Play();
        }
    }
}
