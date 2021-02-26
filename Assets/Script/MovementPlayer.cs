using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardSpeed = 1000f;
    public float sidesSpeed = 1500f;
    
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);

        rb.AddForce(sidesSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0, ForceMode.VelocityChange);

        // If the player fall, the player fail
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().levelFail();
            this.enabled = false;
        }
    }
}
