using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSC : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] float gravityScale, jumpTime;
    [SerializeField] float jumpForce, gravity, fallY;
    [SerializeField] private Collider doorC;
    public Walls walls;
    
    GroundCheck ground;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        ground = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && ground.IsGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        fallY = playerRB.velocity.y;

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), gravity, Input.GetAxis("Vertical"));
        input.Normalize();

        if (Input.GetButton("Fire3"))
        {
            transform.Translate(input * runSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(input * walkSpeed * Time.deltaTime);
        }
    }

    public void Jump()
    {
        playerRB.AddForce(new Vector3(playerRB.velocity.x, jumpForce, playerRB.velocity.z), ForceMode.Impulse);
        Invoke("ChangeGravity", jumpTime);

    }
    public void ChangeGravity()
    {
        gameObject.GetComponent<CustomGravity>().changeGravity(gravityScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == doorC)
        {
            walls.kinematicDisable = true;
        }
    }
}
