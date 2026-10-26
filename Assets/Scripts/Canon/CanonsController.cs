using UnityEngine;
using System.Collections;
using static CanonsController;

public class CanonsController : MonoBehaviour
{
    [Header("Canon spawn")]
    [SerializeField] public GameObject canonObj;
    public int respawnTime = 9;
    private float temporizador;

    public Canon canon;



    [Header("Datos de los cañones")]
    public int indiceRandom; 
    public int randomX;
    public int randomY;
    public int inicialPosicionY;
    public int inicialPosicionX;
    public Vector2 startPosition;
    public Vector2 finishPosition;
    public int cantidadRotacionZ;
    public float tamañoCanon = 5.1f;



    void Start()
    {
        
    }

    void Update()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= respawnTime)
        {
            canon = CrearCañonAleatorio();
            Instantiate(canonObj, canon.startPosition, Quaternion.Euler(0, 0, canon.cantidadRotacionZ));
            temporizador = 0;
        }

        
    }



    public Canon CrearCañonAleatorio()
    {
        indiceRandom = Random.Range(0, 4); // 0 = top | 1 = derecha | 2 = bot | 3 = izquierda

        if (indiceRandom == 0)
        {
            cantidadRotacionZ = 0;
            randomX = Random.Range(-30, 31);
            inicialPosicionY = 21;
            startPosition = new Vector2(randomX, inicialPosicionY);
            finishPosition = new Vector2(randomX, inicialPosicionY - tamañoCanon);
        }

        if (indiceRandom == 1)
        {
            cantidadRotacionZ = 90;
            randomY = Random.Range(-15, 16);
            inicialPosicionX = 35;
            startPosition = new Vector2(inicialPosicionX, randomY);
            finishPosition = new Vector2(inicialPosicionX - tamañoCanon, randomY);
        }

        if (indiceRandom == 2)
        {
            cantidadRotacionZ = 0;
            randomX = Random.Range(-30, 31);
            inicialPosicionY = -21;
            startPosition = new Vector2(randomX, inicialPosicionY);
            finishPosition = new Vector2(randomX, inicialPosicionY + tamañoCanon);
        }

        if (indiceRandom == 3)
        {
            cantidadRotacionZ = 90;
            randomY = Random.Range(-15, 16);
            inicialPosicionX = -35;
            startPosition = new Vector2(inicialPosicionX, randomY);
            finishPosition = new Vector2(inicialPosicionX + tamañoCanon, randomY);
        }
        Canon canon = new Canon(startPosition, finishPosition, cantidadRotacionZ, indiceRandom);
        return canon;
    }



    public class Canon
    {
        public Vector2 startPosition;
        public Vector2 finishPosition;

        public int cantidadRotacionZ;
        public int indiceRandom;

        public Canon(Vector2 startPosition, Vector2 finishPosition, int cantidadRotacionZ, int indiceRandom)
        {
            this.cantidadRotacionZ = cantidadRotacionZ;
            this.startPosition = startPosition;
            this.finishPosition = finishPosition;
            this.indiceRandom = indiceRandom;

        }
    }
}
