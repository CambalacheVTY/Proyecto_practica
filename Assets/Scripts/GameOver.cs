using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject gameOverUI;
    private GameObject gameStartUI;
    private bool isGameOver = false;

    private void Start()
    {
        gameOverUI = GameObject.Find("GameOverPanel");
        gameStartUI = GameObject.Find("GameStartPanel");

        gameOverUI?.SetActive(false);  // Con el operador ?. evitamos errores si es null
        gameStartUI?.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            isGameOver = true;
        }
    }

    private void Update()
    {
        if (isGameOver && Input.anyKeyDown)
        {
            gameOverUI?.SetActive(false);
            gameStartUI?.SetActive(true);  // Mostrar el panel de inicio
            Time.timeScale = 1f;           // Reanudar el juego
            isGameOver = false;
        }
    }
}