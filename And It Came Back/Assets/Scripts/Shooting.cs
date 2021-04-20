using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && PauseMenu.GameIsPaused == false)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Check if the player currently has an ability
        switch (GetComponent<PlayerScript>().ability)
        {
            //If the player has a shooting ability, activate it
            case Powerup.PowerupType.Triple:
                Powerup.activateTriplePlayer(gameObject, bulletPrefab);
                GetComponent<PlayerScript>().ability = Powerup.PowerupType.NA;
                break;
            case Powerup.PowerupType.Auto:
                //Powerup.activateAutoPlayer(gameObject);
                break;
            case Powerup.PowerupType.Bomb:
                //Powerup.activateBombPlayer(gameObject);
                break;
            //If there is no ability, shoot normally
            default:
                ShootNormal();
                break;
        }
    }

    //Shoots a bullet from firingPoint with bulletForce
    // Returns the bullet created
    public GameObject ShootNormal()
    {
        //Create a bullet at the player's firepoint and add a forward force
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        return bullet;
    }
}

