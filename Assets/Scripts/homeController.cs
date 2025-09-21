using UnityEngine;
using TMPro;

public class HomeController : MonoBehaviour
{
    public int round = 1;
    public TextMeshProUGUI roundText;

    public GameObject chasePrefab;
    public GameObject bouncePrefab;
    public GameObject coinPrefab;

    public Transform[] coinSpawnPoints;

    private void Start()
    {
        UpdateRoundUI();

        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BasicMove player = other.GetComponent<BasicMove>();

            if (player != null && player.coinCount > 0)
            {
                
                player.coinCount--;

                
                round++;

               
                UpdateRoundUI();

                
                SpawnCoin();

                if (round == 1)
                {
                    SpawnChase();
                }

                if (round % 3 == 0)
                {
                    SpawnBounce();
                }

                if (round % 10 == 0)
                {
                    SpawnChase();
                }
            }
        }
    }

    void UpdateRoundUI()
    {
        if (roundText != null)
        {
            roundText.text = "Round: " + round;
        }
    }

    void SpawnCoin()
    {
        int randomIndex = Random.Range(0, coinSpawnPoints.Length);
        Transform spawnPoint = coinSpawnPoints[randomIndex];

        Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
    }

    void SpawnBounce()
    {
        int randomIndex = Random.Range(0, coinSpawnPoints.Length);
        Transform spawnPoint = coinSpawnPoints[randomIndex];

        Instantiate(bouncePrefab, spawnPoint.position, Quaternion.identity);
    }

    void SpawnChase()
    {
        int randomIndex = Random.Range(0, coinSpawnPoints.Length);
        Transform spawnPoint = coinSpawnPoints[randomIndex];

        Instantiate(chasePrefab, spawnPoint.position, Quaternion.identity);
    }
}