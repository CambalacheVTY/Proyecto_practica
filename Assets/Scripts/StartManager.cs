using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject gameStartPanel;

    private bool gameStarted = false;

    void Start()
    {
        if (gameStartPanel != null)
            gameStartPanel.SetActive(true);

        Time.timeScale = 0f; // Pausar al inicio
    }

    void Update()
    {
        if (!gameStarted && Input.anyKeyDown)
        {
            gameStarted = true;
            if (gameStartPanel != null)
                gameStartPanel.SetActive(false);

            Time.timeScale = 1f; // Reanudar juego
        }
    }
}