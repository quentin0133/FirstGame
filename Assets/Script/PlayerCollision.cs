using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public MovementPlayer movement;

    private void OnCollisionEnter(Collision collision)
    {
        // If the player hit a obstacle, the player fail
        if (collision.collider.tag == "Obstacle") {
            movement.enabled = false;
            FindObjectOfType<GameManager>().levelFail();
        }
    }
}
