using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            BasicMove player = other.GetComponent<BasicMove>();

            if (player != null)
            {
                player.CollectCoin();
            }

            Destroy(gameObject);
        }
    }
}