using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorDeEscena : MonoBehaviour
{

    [SerializeField] private string EscenaDelJuego;
    [SerializeField] private string EscenaFinal;
    [SerializeField] private string EscenaInicial;
    [SerializeField] public GameObject playerObj;
    [SerializeField] public GameObject puntosObj;





    private void Update()
    {

        if (SceneManager.GetActiveScene().name == "EscenaDelJuego")
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj == null)
            {
                DontDestroyOnLoad(puntosObj);
                SceneManager.LoadScene(EscenaFinal);
            }
        }
    }

    public void CargarEscena()
    {

        if (SceneManager.GetActiveScene().name == "EscenaInicial")
        {
            SceneManager.LoadScene(EscenaDelJuego);
        }
        else if (SceneManager.GetActiveScene().name == "EscenaFinal")
        {
            SceneManager.LoadScene(EscenaDelJuego);
        }
    }
}
