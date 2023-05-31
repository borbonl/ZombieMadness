using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmovment : MonoBehaviour
{

    public Rigidbody playerRB;

    public OpenPiramid piramid;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "player1")
        {
            playerRB.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
            piramid.open = true;
            StartCoroutine("DoVolume");
            GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator DoVolume()
    {
        for (int i = 1; i <= 8; i++)
        {
            yield return new WaitForSeconds(1f);
            GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume + 0.1f;
        }
    }
}
