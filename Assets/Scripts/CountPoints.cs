using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CountPoints : MonoBehaviour
{
    private float pointsFMin;
    private float numberOfPoints;
    public int viewPoints;
    private string mensage;
    private GameObject[] bouncingBallsObjts;
    private GameObject tmpObj;

    private TextMeshProUGUI tmp;
    void Start()
    {
        numberOfPoints = 0f;
        viewPoints = 0;
    }

    void Update()
    {
        bouncingBallsObjts = GameObject.FindGameObjectsWithTag("bouncingEnemy");
        int bouncigBallCant = bouncingBallsObjts.Length;
        tmpObj = GameObject.FindGameObjectWithTag("Puntos");
        tmp = tmpObj.GetComponent<TextMeshProUGUI>();
        if (SceneManager.GetActiveScene().name == "EscenaDelJuego")
        {
            numberOfPoints += (bouncigBallCant + 1) * Time.deltaTime;
        }
        viewPoints = Mathf.RoundToInt(numberOfPoints);
        mensage = $"Puntaje: {viewPoints}";
        Debug.Log(tmp);
        tmp.text = mensage;
    }
}
