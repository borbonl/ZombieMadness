using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPiramid : MonoBehaviour
{
    public Rigidbody playerRB;

    public bool open = false;

    public AudioClip musicTunnel;

    public GameManager gameManager;

    public Animator finalCanvAnim;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "player1" && open)
        {
            GetComponent<Animator>().SetBool("open", true);
            playerRB.constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<AudioSource>().Play();
            StartCoroutine("Tunnel");
        }
    }

    IEnumerator Tunnel()
    {
       yield return new WaitForSeconds(1);
        GetComponent<AudioSource>().clip = musicTunnel;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(8);
        gameManager.final();
        finalCanvAnim.SetTrigger("final");
    }

}
