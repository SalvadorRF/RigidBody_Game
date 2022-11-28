using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10;
    public float impulseForce = 10;
    public bool randomJump = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerController PlayerController = collision.gameObject.GetComponent<PlayerController>();
            Rigidbody playerRigidbody = PlayerController.GetComponent<Rigidbody>();

            if (PlayerController.isGrounded)
            {
                if (randomJump)
                {
                    playerRigidbody.AddForce(transform.forward * jumpForce * 30, ForceMode.Impulse);
                    playerRigidbody.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);
                }
                else
                {
                    playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
            }
        }
    }
}
