using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSC : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB, doorRB;
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] float gravityScale, jumpTime;
    [SerializeField] float jumpForce, gravity, fallY;
    [SerializeField] private Collider doorC, ghostC;
    public Transform doorT;
    public Walls walls;
    public GhostCloth ghostCloth;
    public GameState gameState;
    public Transform orientation;

    GroundCheck ground;

    void Awake()
    {
        ground = GetComponentInChildren<GroundCheck>();
    }
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Jump();
        PlaneChange();
    }
    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlaneChange()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            gameState.SetNextPlaneMode();
        }
        else if (scroll < 0f)
        {
            gameState.SetPrevPlaneMode();
        }
    }
    void PlayerMovement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(inputX, 0f, inputY);
        input.Normalize();

        float speed = Input.GetButton("Fire3") ? runSpeed : walkSpeed;

        Vector3 velocity = Quaternion.AngleAxis(orientation.rotation.eulerAngles.y, Vector3.up) * input * speed * Time.deltaTime;
        transform.position += velocity;
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && ground.IsGrounded)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Invoke("ChangeGravity", jumpTime);
        }
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
            doorRB.GetComponent<Rigidbody>().isKinematic = true;
            doorT.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (other == ghostC)
        {
            ghostCloth.collitionE = true;
            gameState.GhostPlaneModeEnabled = true;
        }
    }
}
