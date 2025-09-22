using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    public GameObject gameOverUI;
    private bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false);

        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isGameOver = false;

        if (gameOverUI != null)
            gameOverUI.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isGameOver && Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void TriggerGameOver()
    {
        if (isGameOver) return;

        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        Time.timeScale = 0f;
        isGameOver = true;
    }
}