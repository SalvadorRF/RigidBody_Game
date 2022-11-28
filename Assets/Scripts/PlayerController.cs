using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private new Rigidbody rigidbody;
  public float movementSpeed;
  public float jumpForce;
  public float angularSpeed;
  private float orgJumpForce;
  public bool isGrounded = true;
  public bool isInJumpPad = false;

  void Start()
  {
    rigidbody = GetComponent<Rigidbody>();
    orgJumpForce = jumpForce;
  }

  void Update()
  {
    float hor = Input.GetAxisRaw("Horizontal");
    float ver = Input.GetAxisRaw("Vertical");

    move(hor, ver, (hor != 0 || ver != 0));
    jump(Input.GetButtonDown("Jump"));

  }

  private void OnCollisionEnter(Collision collision)
  {

    if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("JumpPad"))
    {
      isGrounded = true;
    }
  }

  private void move(float hor, float ver, bool move)
  {
    Vector3 velocity = Vector3.zero;

    if (move)
    {
      Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;
      velocity = direction * movementSpeed;
    }

    velocity.y = rigidbody.velocity.y;
    rigidbody.velocity = velocity;
  }

  private void jump(bool jump)
  {
    if (jump && isGrounded)
    {
      rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isGrounded = false;
    }
  }
}
