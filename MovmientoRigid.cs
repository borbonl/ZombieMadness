using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmientoRigid : MonoBehaviour
{

    public float m_Speed = 20f;
    Rigidbody rd;

    
    public GameManager gamemanager;

    GameObject hurtCanvas;

    int healt = 14;

    void Start()
    {
        rd = GetComponent <Rigidbody>();
        hurtCanvas = GameObject.Find("PanelHurt");
    }


    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "zombie") { 
            healt--;
            hurtCanvas.GetComponent<Animator>().SetTrigger("hurt");
            if (healt <= 0) 
                gamemanager.GameOver();

        }
    }

    void Update()
    {


        if (Input.GetKey(KeyCode.UpArrow))
        {
            rd.velocity = new Vector3(transform.forward.x * m_Speed, rd.velocity.y, transform.forward.z * m_Speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rd.velocity = new Vector3(-transform.forward.x * m_Speed, rd.velocity.y, -transform.forward.z * m_Speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rd.velocity = new Vector3(transform.right.x * m_Speed, rd.velocity.y, transform.right.z * m_Speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rd.velocity = new Vector3(transform.right.x * m_Speed*-1, rd.velocity.y, transform.right.z * m_Speed*-1);
        }


        
        if (!Input.anyKey )
        {
            if (rd.velocity.y <= 0)
            {
                rd.velocity = new Vector3(0, rd.velocity.y, 0);
            }
            else {
                rd.velocity = new Vector3(0, 0, 0);
            }
        }
    }


}
