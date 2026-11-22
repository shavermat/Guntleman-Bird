using UnityEngine;

public class FreedyPhysics : MonoBehaviour
{
private Rigidbody2D rb;
public float fallSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocityY < 0)
        {
            rb.linearVelocity = new Vector2 (rb.linearVelocityX, rb.linearVelocityY * fallSpeed);
        }
    }
}
