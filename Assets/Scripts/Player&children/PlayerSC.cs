using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSC : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float artificialGravity = 5f;
    [SerializeField] private float ballReloadTime = 1f;
    [SerializeField] private GameObject ballPF;
    [SerializeField] private float ballThrowForce = 6f;
    [SerializeField] private Transform hand;
    public PlayerCollitionsBody playerC;
    public MaterializeObjects mtSC;
    private float jumpHeight = 2f;
    private float ballReload = 0f;
    public GameState gameState;
    public Transform orientation;
    public bool ballInHand = false;
    public bool canThrowBall = false;
    public bool canMaterialized = false;
    public int ballCount = 0;
    public int currBallsInHand;
    private GameObject ball = null;
    GameObject ps;
    float coyoteTime = 0.2f;
    float coyoteTimeCounter;    
    float jumpBufferTime = 0.2f;
    float jumpBufferCounter;

    GroundCheck ground;

    void Awake()
    {
        ground = GetComponentInChildren<GroundCheck>();
        playerRB = GetComponent<Rigidbody>();

        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }
    private void OnEnable()
    {
        playerRB.constraints = RigidbodyConstraints.None;
        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void OnDisable()
    {
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void Update()
    {
        CoyoteTime();
        BufferTime();
        Jump();

        if (mtSC.materializanding == false)
        {
            PlaneChange();
        }

        if (playerC.ballEnable)
        {
            BallGrabAndThrow();
        }
        if (playerC.justOneWhenPick)
        {
            currBallsInHand++;
            playerC.justOneWhenPick = false;
        }

        if (Input.GetButtonDown("Reinicio"))
        {
            ReloadScene();
        }
    }
    void FixedUpdate()
    {
        PlayerMovement();
        playerRB.AddForce(Vector3.down * artificialGravity);
    }
    public void ResetSpawnPlayer()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
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

        float speed = (Input.GetButton("Left Shift")) ? runSpeed : walkSpeed;//velocidad si camina o si corre

        Vector3 velocity = Quaternion.AngleAxis(orientation.rotation.eulerAngles.y, Vector3.up) * input * speed * Time.fixedUnscaledDeltaTime;
        transform.position += velocity;
    }

    void CoyoteTime()
    {
        if (ground.IsGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }
    
    void BufferTime()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    void Jump()
    {
        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            float jumpvelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            playerRB.velocity = new Vector3(playerRB.velocity.x, jumpvelocity, playerRB.velocity.z);
            jumpBufferCounter = 0;
            coyoteTimeCounter = 0;
        }
    }
    public void OnPlaneModeChanged(GameState.PlaneMode planeMode)
    {
        canThrowBall = planeMode == GameState.PlaneMode.Ghost;
    }
    //Comportamiento del player con la pelota y las condiciones para que reproduzca la mecanica de tirar y agarrar
    private void BallGrabAndThrow()
    {
        if (!canThrowBall && ballInHand)
        {
            if (ball != null)
                Destroy(ball);
            return;
        }
        ballCount = currBallsInHand;
        if (ball == null && ballCount > 0)
        {
            if (ballReload < ballReloadTime)
                ballReload += Time.deltaTime;
            else
            {
                ball = Instantiate(ballPF, hand);
                ball.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        if (ball != null && Input.GetButtonDown("LeftClick"))
        {
            ballCount--;
            ballReload = 0f;
            ball.transform.parent = null;
            ball.GetComponent<Rigidbody>().isKinematic = false;
            ball.GetComponent<Rigidbody>().AddForce(hand.transform.forward * ballThrowForce, ForceMode.Impulse);
            ball.transform.GetChild(0).gameObject.SetActive(true);
            ball = null;
            currBallsInHand = ballCount;
            Debug.Log(" A tiraR, Tengo " + currBallsInHand + " pelotas de " + ballCount);
        }
        
    }
    public void PickupBalls()
    {
        ballCount = 5;
        currBallsInHand = ballCount;
        Debug.Log(" A la agarrar, Tengo " + currBallsInHand + " pelotas de " + ballCount);
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}
