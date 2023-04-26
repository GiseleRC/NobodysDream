using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSC : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float dreamPlaneJumpHeight = 1f;
    [SerializeField] private float ghostPlaneJumpHeight = 1f;
    [SerializeField] private float demonPlaneJumpHeight = 1f;
    [SerializeField] private float artificialGravity = 5f;
    private float jumpHeight;
    public GameState gameState;
    public Transform orientation;
    private bool runEnabled = true;

    GroundCheck ground;

    void Awake()
    {
        jumpHeight = dreamPlaneJumpHeight;

        ground = GetComponentInChildren<GroundCheck>();
        playerRB = GetComponent<Rigidbody>();
    }
    void Start()
    {
    }
    private void Update()
    {
        Jump();
        PlaneChange();
    }
    void FixedUpdate()
    {
        PlayerMovement();
        playerRB.AddForce(Vector3.down * artificialGravity);
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

        float speed = (runEnabled && Input.GetButton("Fire3")) ? runSpeed : walkSpeed;//velocidad si camina o si corre

        Vector3 velocity = Quaternion.AngleAxis(orientation.rotation.eulerAngles.y, Vector3.up) * input * speed * Time.fixedUnscaledDeltaTime;
        transform.position += velocity;
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && ground.IsGrounded)
        {
            float jumpvelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            playerRB.velocity = new Vector3(playerRB.velocity.x, jumpvelocity, playerRB.velocity.z);
        }
    }
    public void OnPlaneModeChanged(GameState.PlaneMode planeMode)
    {
        runEnabled = planeMode != GameState.PlaneMode.Ghost;

        switch (planeMode)
        {
            case GameState.PlaneMode.Dream:
                jumpHeight = dreamPlaneJumpHeight;
                break;
            case GameState.PlaneMode.Ghost:
                jumpHeight = ghostPlaneJumpHeight;
                break;
            case GameState.PlaneMode.Demon:
                jumpHeight = demonPlaneJumpHeight;
                break;
        }
    }
}
