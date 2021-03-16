/* Script by William McDonald and Johnathon Cortez, March 6th 9:40pm.
 * Movement script, for moving an asset with the  'WASD' keys, can be future modified for controller input.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 10.4f;

    // Update is called once per frame
    void Update()
    {
        move();
        faceMouse();
    }

    void move() {
        Vector3 newPos = transform.position;
        newPos.x += speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        newPos.y += speed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.position = newPos;
    }

    void faceMouse() {
        transform.LookAt(Input.mousePosition);
    }
}