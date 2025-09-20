using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float forceAmount = 10f;      
    public float maxSpeed = 5f;         

    private Rigidbody2D rb;

    void Start()
    {
        Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody2D>();
        
        rb.drag = 2f;        //friction
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        
        if (rb.velocity.magnitude < maxSpeed) //avoid infinite speed
        {
            rb.AddForce(direction * forceAmount);
        }

       
    }
}