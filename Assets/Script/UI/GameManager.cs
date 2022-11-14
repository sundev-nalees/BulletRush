using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace BulletRush
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int KillScore;
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject won;
        [SerializeField] private float winScore;
        [SerializeField] private GameObject player;

        
        private int currentScore;
        private const string defaultText = "SCORE :";


        private void OnEnable()
        {
            EventManager.Instance.OnEnemyDeath += UpdateScore;
            EventManager.Instance.OnGameOver += OnGameOver;
        }

        private void Start()
        {
            gameOver.SetActive(false);
            won.SetActive(false);
        }
        private void Update()
        {
            if (currentScore == winScore)
            {
                won.SetActive(true);
                player.SetActive(false);

            }
        }

        private void UpdateScore()
        {
            currentScore += KillScore;
            score.text = defaultText + currentScore;
        }

        private void OnGameOver()
        {
            gameOver.SetActive(true);
        }
        

        public void Quit()
        {
            Application.Quit();
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);

        }

        
    }
}
