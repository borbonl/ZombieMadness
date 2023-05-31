using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public float damageAmount = 1f;

    public float range = 150;

    public Camera PlayerCam;

    public int hurtzombie = 5, hZombieH = 1;
  
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GetComponent<AudioSource>().Play();
        RaycastHit hit;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range))
        {
            MovZombie zombie = hit.transform.GetComponent<MovZombie>();
            if (zombie != null)
            {
                if (hit.collider.name == "zombieHead")
                    zombie.hurt(hZombieH);
                else if (hit.collider.tag == "zombie")
                    zombie.hurt(hurtzombie);
            }

            MovSphere spherex = hit.transform.GetComponent<MovSphere>();
            if (spherex != null)
            {
                spherex.Brillo();
            }

        }

    }
}
