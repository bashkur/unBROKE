using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    BreakableObjectScript broken;
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
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(jumpForce);
            isGrounded = false;
        }

    }

    private void FixedUpdate()
    {
        Vector3 horiz = Input.GetAxis("Horizontal") * this.transform.right;
        Vector3 vert = Input.GetAxis("Vertical") * this.transform.forward;
        Vector3 new_pos = (horiz + vert) * move_speed * Time.deltaTime;
        rb.MovePosition(transform.position + new_pos);

        if (new_pos == Vector3.zero)
            animator.SetBool("Running", false);
        else
            animator.SetBool("Running", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isGrounded = true;
        //gets game object scripts sees if it is destroyed then can heal!
 
        if(collision.gameObject.tag=="Breakable")
        {
            print("HIT");
            broken=collision.gameObject.GetComponent<BreakableObjectScript>();
            if (broken.isDestroyed() == true)

            {
                if (Input.GetKeyDown("e"))
                {
                    broken.heal();
                }
                if(Input.GetKeyDown("r"))
                {
                    print(broken.maxHealth);
                    broken.damage();
                }
             }
        }
    }
}
