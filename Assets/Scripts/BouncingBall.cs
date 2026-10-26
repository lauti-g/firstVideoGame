using UnityEngine;


public class BouncingBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject audioControllerObj;
    private AudioController audioController;
    public GameObject canonObj;
    public CanonsController.Canon canon;


    private Vector2 move;


    public float speed = 15;
    private bool flag = false;






    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioControllerObj = GameObject.FindGameObjectWithTag("AudioController");
        audioController = audioControllerObj.GetComponent<AudioController>();


        canonObj = GameObject.FindGameObjectWithTag("CanonsController");
        canon = canonObj.GetComponent<CanonsController>().canon;


        if (canon.indiceRandom == 0)
        {
            move = Vector2.down;
            
        }
        else if (canon.indiceRandom == 2)
        {
            move = Vector2.up;
            
        }
        else if (canon.indiceRandom == 3)
        {
            move = Vector2.right;
            
        }
        else if (canon.indiceRandom == 1)
        {
            move = Vector2.left;
            
        }

    }



    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }



    void OnCollisionEnter2D(Collision2D colision)
    {
        if (flag) 
        {
            rb.useFullKinematicContacts = true;
            ContactPoint2D[] contactos = colision.contacts;
            move = contactos[0].normal;
            audioController.sonidoRebote = true;
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        flag = true;
        rb.useFullKinematicContacts = true;
    }
}
