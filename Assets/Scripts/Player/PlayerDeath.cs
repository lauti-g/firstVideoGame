using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Evil" || collision.gameObject.tag == "bouncingEnemy")
        {
            Destroy(gameObject);

        }
        
    }
}
