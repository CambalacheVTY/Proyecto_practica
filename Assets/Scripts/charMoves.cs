using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float forceAmount = 10f;
    public float maxSpeed = 5f;

    private Rigidbody2D rb;

    public Collider2D mainCollider;
    public Collider2D parryCollider;

    public SpriteRenderer mainRenderer;
    public SpriteRenderer parryRenderer;

    public int coinCount = 0;

    private bool isParrying = false;
    private bool isOnCooldown = false;

    public float parryDuration = 0.6f;
    private float parryTimer = 0f;

    private float parryCooldown = 2f;
    private float cooldownTimer = 0f;

    void Start()
    {
        Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody2D>();
        rb.drag = 2f;

        parryCollider.enabled = false;

        if (mainRenderer != null)
            mainRenderer.color = Color.white;

        if (parryRenderer != null)
            parryRenderer.color = Color.clear;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(direction * forceAmount);
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !isParrying && !isOnCooldown)
        {
            ActivateParry();
        }

        if (isParrying)
        {
            parryTimer -= Time.deltaTime;
            if (parryTimer <= 0f)
            {
                DeactivateParry();
            }
        }

        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                isOnCooldown = false;
            }
        }
    }

    public void ActivateParry()
    {
        isParrying = true;
        parryTimer = parryDuration;
        parryCollider.enabled = true;

        if (parryRenderer != null)
            parryRenderer.color = Color.cyan;
    }

    public bool IsParrying()
    {
        return isParrying;
    }

    public void DeactivateParry()
    {
        isParrying = false;
        parryCollider.enabled = false;
        isOnCooldown = true;
        cooldownTimer = parryCooldown;

        if (parryRenderer != null)
            parryRenderer.color = Color.clear;
    }


    public void CollectCoin()
    {
        coinCount++;
        Debug.Log("Monedas recogidas: " + coinCount);
    }
}