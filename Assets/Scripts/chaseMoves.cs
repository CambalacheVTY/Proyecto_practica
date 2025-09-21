using UnityEngine;

public class goToTarget : MonoBehaviour
{
    public Transform target;           
    public float speed = 10f; 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    void FixedUpdate()
    {


        Vector2 direction = (target.position - transform.position).normalized;
        rb.AddForce(direction * speed);

       


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
