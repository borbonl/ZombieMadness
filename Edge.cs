using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gameManager;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "zombie")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "player1" && gameObject.tag != "Respawn")
        {
            gameManager.GameOver();
        }

    }

}
