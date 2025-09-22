using UnityEngine;
using UnityEngine.InputSystem;

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

    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction parryAction;

    private Vector2 moveInput = Vector2.zero;

    void Awake()
    {
        var playerMap = inputActions.FindActionMap("Player", true);

        moveAction = playerMap.FindAction("Move", true);
        parryAction = playerMap.FindAction("Parry", true);

        moveAction.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => moveInput = Vector2.zero;

        parryAction.performed += ctx =>
        {
            if (!isParrying && !isOnCooldown)
            {
                ActivateParry();
            }
        };
    }

    void OnEnable()
    {
        moveAction?.Enable();
        parryAction?.Enable();
    }

    void OnDisable()
    {
        moveAction?.Disable();
        parryAction?.Disable();
    }

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
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveInput.normalized * forceAmount);
        }
    }

    void Update()
    {
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
        
    }
}