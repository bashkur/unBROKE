using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float move_speed = 3.0f;

    private CharacterController controller = null;
    private Animator animator = null;
    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 horiz = Input.GetAxis("Horizontal") * this.transform.right;
        Vector3 vert = Input.GetAxis("Vertical") * this.transform.forward;
        Vector3 new_pos = (horiz + vert) * move_speed * Time.deltaTime;
        rb.MovePosition(transform.position + new_pos);
    }
}
