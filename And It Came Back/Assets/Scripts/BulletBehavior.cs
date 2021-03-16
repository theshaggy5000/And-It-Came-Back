using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [HideInInspector]public Rigidbody2D rb2d;
    public float speed = 10f;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(1, 1) * speed;
    }



    void Awake()
    {
        
    }

    

    void FixedUpdate()
    {
        Debug.Log(Physics2D.GetLayerCollisionMask(gameObject.layer));
        Debug.Log((bool)Physics2D.Raycast(transform.position, rb2d.velocity, speed, Physics2D.GetLayerCollisionMask(gameObject.layer)));
        Debug.DrawRay(transform.position, rb2d.velocity, Color.cyan);
    }
}
