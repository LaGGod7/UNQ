using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 movement;
    public float moveSpeed;
    
    public Sprite lsprite;
    public Sprite ssprite;
    public Sprite wsprite;
    public Sprite rsprite;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = ssprite;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x > 0) { sr.sprite = rsprite; }
        else if (movement.x < 0) { sr.sprite = lsprite; }
        else if (movement.y < 0) { sr.sprite = ssprite; }
        else if (movement.y>0){ sr.sprite = wsprite; }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
