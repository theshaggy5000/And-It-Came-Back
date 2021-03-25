using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public bool infiniteBounces = true; //Whether the bullet should bounce infinitely or not
    public int bounceCount = 0;         //The number of walls the bullet has bounced off of
    public int maxBounces = 5;          //The max number of bounces of a bullet

    void OnCollisionEnter2D(Collision2D other)
    {
        // Event when a bullet hits the player.
        if (other.gameObject.tag == "Player")
            Destroy(gameObject);

        // Event when a bullet hits a wall and infinte bounces is turned off.
        if (!infiniteBounces && other.gameObject.tag == "Walls")
        {
            bounceCount += 1;
            if (bounceCount == maxBounces)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Event when a bullet hits a powerup
        if (other.gameObject.tag == "Powerup")
            other.GetComponent<powerup>().activate(this.gameObject);
    }
}