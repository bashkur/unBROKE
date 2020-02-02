using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float move_speed = 3.0f;
    [SerializeField]
    private Vector3 jumpForce;

    private bool isGrounded;

    //private CharacterController controller = null;
    private Animator animator = null;
    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        //controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            print("jump");
            rb.AddForce(jumpForce);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        //animator.SetBool("Grounded", isGrounded);

        Vector3 horiz = Input.GetAxis("Horizontal") * this.transform.right;
        Vector3 vert = Input.GetAxis("Vertical") * this.transform.forward;
        Vector3 new_pos = (horiz + vert) * move_speed * Time.deltaTime;
        rb.MovePosition(transform.position + new_pos);

        if (new_pos == Vector3.zero)
            animator.SetBool("Running", false);
        else
            animator.SetBool("Running", true);

        //print(isGrounded);



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}
