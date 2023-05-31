using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovZombie : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed;
    public bool band = false;

    bool band3 = true;

    int hits = 0;

    public int hitb = 5, hith = 1;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void hurt(int opcio)
    {

        GetComponent<Animator>().SetTrigger("hit");
        hits++;

        if (opcio == 1)
        {
            if (hits >= hitb)
            {
                band = false;
                GetComponent<Animator>().SetBool("die", true);
                GetComponent<AudioSource>().Stop();
                StartCoroutine("Destroy");
            }
        }
        if (opcio == 2)
        {
            if (hits >= hith)
            {
                band = false;
                GetComponent<Animator>().SetBool("die", true);
                GetComponent<AudioSource>().Stop();
                StartCoroutine("Destroy");
            }
        }
    }

    private void OnTriggerEnter(Collider collision2)
    {
    if (collision2.gameObject.name == "player1" && band3)
        {
            band3 = false;
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetBool("walk", true);
            StartCoroutine("WaitScream");
            
        }
    }

    void Update()
    {

        if( band) {
            m_Rigidbody.velocity = new Vector3(transform.forward.x * m_Speed, m_Rigidbody.velocity.y, transform.forward.z * m_Speed);
        }


        if (Time.timeScale == 0)
        {
            GetComponent<AudioSource>().Pause();
        }

        if (band && Time.timeScale == 1 && !GetComponent<AudioSource>().isPlaying) {

            GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.7f);
        Destroy(gameObject);
    }

    IEnumerator WaitScream()
    {
        yield return new WaitForSeconds(7.2f);
        band = true;
    }


}
