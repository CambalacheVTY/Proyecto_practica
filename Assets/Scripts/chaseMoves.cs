using UnityEngine;

public class goToTarget : MonoBehaviour
{
    public float speed = 10f;
    public float bounceForce = 100f;

    private Rigidbody2D rb;
    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        speed = Random.Range(15f, 25f);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.AddForce(direction * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            Vector2 bounceDirection = (transform.position - other.transform.position).normalized;
            rb.AddForce(bounceDirection * bounceForce);
        }

        
        if (other.CompareTag("Player"))
        {
            BasicMove player = other.GetComponent<BasicMove>();
            if (player != null)
            {
                if (!player.IsParrying())
                {
                    GameOverManager.instance?.TriggerGameOver();
                }
                else
                {
                    
                    Vector2 bounceDirection = (transform.position - other.transform.position).normalized;
                    rb.AddForce(bounceDirection * bounceForce * 5);
                }
            }
        }
    }
}
