using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrig : MonoBehaviour
{

    public float rotation = 0.5f, rotTime = 0.01f;

    float rot2 = 0;

    float i;
    float angle = 0;

    int x = 0;

    bool band2 = true, band3 = true;

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "rota" && collision.gameObject.name == "ColliZombiRot (21)" && transform.parent.gameObject.name == "Zombie (69)" )
        {
            band3 = false;
        }

        if (collision.tag == "rota" && band2 )
        {
            transform.parent.GetComponent<MovZombie>().band = false;
            band2 = false;
            StartCoroutine("DoCheck");
        }
    }

    IEnumerator DoCheck()
    {
        rot2 = rotation;
        if (rotation < 0) {
            rot2 = -rotation;
        }

        for (i = -1.0f; i >= -90; i = i - rot2)
        {
            transform.parent.Rotate(0, -rotation, 0, Space.Self);
            angle = angle - rotation;
            x++;
            yield return new WaitForSeconds(0.01f);

        }

        if (band3)
        {
            transform.parent.GetComponent<MovZombie>().band = true;
            angle = 0;
            x = 0;
            yield return new WaitForSeconds(5f);
            band2 = true;
        }
        else {
            transform.parent.GetComponent<Animator>().SetBool("walk", false);
            transform.parent.GetComponent<Animator>().SetTrigger("idle1");
        }
    }




}
