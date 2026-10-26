using UnityEngine;

public class BallFollower : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 posicion;
    private Vector2 move;
    public float speed = 15f;
    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player)
        {
            posicion = player.transform.position;
            move = (posicion - rb.position).normalized;

            rb.MovePosition(rb.position + move * Time.fixedDeltaTime * speed);
        }
    }
}
