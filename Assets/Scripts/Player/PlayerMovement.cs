using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private InputAction move;
    public Vector2 posicion;
    private Rigidbody2D rb;



    void Awake()
    {
        speed = 21f;
        move = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        posicion = move.ReadValue<Vector2>().normalized;
        
        if (move.IsPressed())
        {
            rb.MovePosition(rb.position + posicion * speed * Time.fixedDeltaTime);
        }
    }
}

