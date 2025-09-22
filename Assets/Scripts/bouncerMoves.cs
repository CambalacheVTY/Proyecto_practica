using UnityEngine;

public class bouncerMoves : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        moveDirection = new Vector2(x, y).normalized;

        speed = Random.Range(5f, speed);
        rb.velocity = moveDirection * speed;
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        Vector2 normal = collision.contacts[0].normal;
        moveDirection = Vector2.Reflect(moveDirection, normal).normalized;
        rb.velocity = moveDirection * speed;

       
        if (collision.collider.CompareTag("Player"))
        {
            BasicMove player = collision.collider.GetComponent<BasicMove>();
            if (player != null && !player.IsParrying())
            {
                GameOverManager.instance?.TriggerGameOver();
            }
        }
    }
}