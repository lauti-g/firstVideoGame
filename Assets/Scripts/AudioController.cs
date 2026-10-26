using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("RAYO")]
    [SerializeField] private AudioClip rayoSound;
    public bool sonidoRayo;
    private bool flagRayoCollectible;


    [Header("BouncingBall")]
    [SerializeField] private AudioClip bouncingBallSound;
    public bool sonidoRebote;



    [Header("Rocket")]
    [SerializeField] private AudioClip rocketSound;
    [SerializeField] private AudioClip explosionRocketSound;
    public bool sonidoRocket;
    public bool explosionSound;
    private bool flagRocketCollectible;



    [Header("Canon")]
    [SerializeField] private AudioClip canonShotSound;
    public bool canonShot;



    [Header("Shield")]
    [SerializeField] private AudioClip shieldSound;
    public bool createShield;




    private AudioSource audioSource;


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        sonidoRebote = false;
        canonShot = false;
        sonidoRayo = false;
        flagRayoCollectible = true;
        flagRocketCollectible = true;
    }

   
    void Update()
    {
        if (sonidoRebote)
        {
            audioSource.PlayOneShot(bouncingBallSound);
            sonidoRebote = false;
        }
        if (canonShot)
        {
            audioSource.volume = 0.24f;
            audioSource.PlayOneShot(canonShotSound);
            canonShot = false;
        }
        if (sonidoRayo)
        {
            if(flagRayoCollectible)
            {
                audioSource.volume = 1f;
                flagRayoCollectible = false;
            }
            else
            {
                audioSource.volume = 0.18f;
            }
            audioSource.PlayOneShot(rayoSound);
            sonidoRayo = false;
        }
        if (sonidoRocket)
        {
            if (flagRocketCollectible)
            {
                audioSource.volume = 1f;
                flagRocketCollectible = false;
            }
            else
            {
                audioSource.volume = 0.18f;
            }
            audioSource.PlayOneShot(rocketSound);
            sonidoRocket = false;
        }
        if (explosionSound)
        {
            explosionSound = false;
            audioSource.PlayOneShot(explosionRocketSound);
        }
        if (createShield)
        {
            audioSource.volume = 0.24f;
            audioSource.PlayOneShot(shieldSound);
            createShield = false;
        }
    }
}
