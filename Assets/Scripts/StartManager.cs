using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    public GameObject gameStartPanel;

    private bool gameStarted = false;

    void Start()
    {
        
        gameStartPanel.SetActive(true); 
      

        Time.timeScale = 0f;

       


        
    }

    void Update()
    {
        if (!gameStarted && Input.anyKeyDown)
        {
            gameStarted = true;
            if (gameStartPanel != null)
            {
                gameStartPanel.SetActive(false);
            }
            Time.timeScale = 1f;
        }
    }

}