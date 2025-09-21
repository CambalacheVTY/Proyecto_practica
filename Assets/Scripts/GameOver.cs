using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject gameOverUI;

    private void Start()
    {
        
        gameOverUI = GameObject.Find("GameOverPanel");
        gameStartUI = GameObject.Find("GameStartPanel");

        gameOverUI.SetActive(false);



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;

            if (Input.anyKeyDown)
            {
                gameOverUI.SetActive(false);
                gameStartPanel = true;

            }
        }
    }
}