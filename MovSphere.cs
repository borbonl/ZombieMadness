using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSphere : MonoBehaviour
{

    int hits = 0;

    public Animator box;

    public AudioClip boxOpen;
    public AudioClip Magic;

    GameObject light;

    AudioSource audioSource;


    public void Brillo()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().SetTrigger("hit");
        hits++;
        
        if (hits == 7)
        {
            GetComponent<Animator>().SetBool("circle", true);
            GetComponent<AudioSource>().clip = Magic;
            GetComponent<AudioSource>().Play();
            StartCoroutine("Destroy");
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10.5f);
        GameObject.Find("Spot Light").SetActive(false);
        GameObject.Find("Spot Light (1)").SetActive(false);
        GameObject.Find("Spot Light (2)").SetActive(false);
        GameObject.Find("Spot Light (3)").SetActive(false);
        GetComponent<AudioSource>().clip = boxOpen;
        GetComponent<AudioSource>().Play();
        box.SetTrigger("Open");
    }

}
