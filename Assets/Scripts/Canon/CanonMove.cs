using UnityEngine;

public class CanonsMove : MonoBehaviour
{

    [Header("Referencias")]
    [SerializeField] private GameObject bouncingBall;




    [Header("Valores Generales")]
    private int contador = 0;
    private float temporizador;
    private int speed;
    private bool flagEntrada;

    public Vector2 startPosition;
    private Vector2 finishPosition;

    private Vector2 bouncingBallPosition;




    private Rigidbody2D rb;
    private GameObject audioControllerObj;
    private AudioController audioController;

    public GameObject canonObj;
    public CanonsController.Canon canon;


    void Start()
    {
        audioControllerObj = GameObject.FindGameObjectWithTag("AudioController");
        audioController = audioControllerObj.GetComponent<AudioController>();


        speed = 60;
        flagEntrada = true;


        canonObj = GameObject.FindGameObjectWithTag("CanonsController");
        canon = canonObj.GetComponent<CanonsController>().canon;

    }


    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        bouncingBallPosition = canon.startPosition;


        // -------------------------------------------------------------------------------
        // ------------------  CAÑON DE TOP    ---------------------------------------------
        //--------------------------------------------------------------------------------
        if (canon.indiceRandom == 0)
        {
            // entrada
            if (rb.position.y >= canon.finishPosition.y && flagEntrada)
            {
                rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);
            }

            // si la posiscion del cañon supera el umbral de la posicion final esto es verdadero
            if (rb.position.y <= canon.finishPosition.y || !flagEntrada)
            {
                // frena la entrada
                flagEntrada = false;

                // dispara  si no se disparo antes
                if (contador == 0)
                {
                    Instantiate(bouncingBall, bouncingBallPosition, Quaternion.identity);
                    audioController.canonShot = true;
                    contador++;
                }



                //temporizador antes que el cañon vuelva para atras
                temporizador += Time.deltaTime;


                if (temporizador >= 3)
                {
                    // cañon vuelve para atras
                    rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
                    // cañon se destruye si vuelve al inicio
                    if (rb.position.y >= canon.startPosition.y)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }



        // -------------------------------------------------------------------------------
        // ------------------  CAÑON DE DERECHA   ---------------------------------------------
        //--------------------------------------------------------------------------------




        if (canon.indiceRandom == 1)
        {


            if (rb.position.x >= canon.finishPosition.x && flagEntrada)
            {
                rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
            }
            if (rb.position.x <= canon.finishPosition.x || !flagEntrada)
            {

                flagEntrada = false;


                if (contador == 0)
                {
                    Instantiate(bouncingBall, bouncingBallPosition, Quaternion.identity);
                    audioController.canonShot = true;
                    contador++;
                }



                temporizador += Time.deltaTime;



                if (temporizador >= 3)
                {
                    rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);

                    if (rb.position.x >= canon.startPosition.x)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }



        // -------------------------------------------------------------------------------
        // ------------------  CAÑON DE BOT  ---------------------------------------------
        //--------------------------------------------------------------------------------



        if (canon.indiceRandom == 2)
        {
            if (rb.position.y <= canon.finishPosition.y && flagEntrada)
            {
                rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
            }

            if (rb.position.y >= canon.finishPosition.y || !flagEntrada)
            {

                flagEntrada = false;


                if (contador == 0)
                {
                    Instantiate(bouncingBall, bouncingBallPosition, Quaternion.identity);
                    audioController.canonShot = true;
                    contador++;
                }



                temporizador += Time.deltaTime;



                if (temporizador >= 3)
                {
                    rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);

                    if (rb.position.y <= canon.startPosition.y)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }


        // -------------------------------------------------------------------------------
        // ------------------  CAÑON DE IZQUIERDA  ---------------------------------------------
        //--------------------------------------------------------------------------------


        if (canon.indiceRandom == 3)
        {


            if (rb.position.x <= canon.finishPosition.x && flagEntrada)
            {
                rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
            }
            if (rb.position.x >= canon.finishPosition.x || !flagEntrada)
            {

                flagEntrada = false;


                if (contador == 0)
                {
                    Instantiate(bouncingBall, bouncingBallPosition, Quaternion.identity);
                    audioController.canonShot = true;
                    contador++;
                }



                temporizador += Time.deltaTime;



                if (temporizador >= 3)
                {
                    rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);

                    if (rb.position.x <= canon.startPosition.x)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
