using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSC : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private GameObject ballPF, ballPickeableGO;
    [SerializeField] private Transform hand;
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float artificialGravity = 5f;
    [SerializeField] private float ballReloadTime = 1f;
    [SerializeField] private float ballThrowForce = 6f;
    [SerializeField] public PhysicMaterial physicMaterial;
    [SerializeField] public int maxCapacityOfBalls = 5;
    private GameObject ball = null;
    GameObject ps;
    public PlayerCollitionsBody playerC;
    public MaterializeObjects mtSC;
    public GameState gameState;
    public Transform orientation;
    public bool canThrowBall = false;
    public bool canMaterialized = false;
    private float jumpHeight = 2f;
    private float ballReload = 0f;
    float coyoteTime = 0.3f;
    float coyoteTimeCounter;
    float jumpBufferTime = 0.2f;
    float jumpBufferCounter;

    public int BallCount { get; private set; } = 0;

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

        //print(ground.IsGrounded);

        if (mtSC.materializanding == false)
        {
            PlaneChange();
        }

        if (playerC.ballEnable)
        {
            BallGrabAndThrow();
        }

        if (Input.GetButtonDown("Reinicio"))
        {
            ReloadScene();
        }

    }
    void FixedUpdate()
    {
        PlayerMovement();

        if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0 && !Input.GetButtonDown("Jump") && !GetComponent<CapsuleCollider>().enabled)
        {
            ResetSpawnPlayer();
            physicMaterial.staticFriction = 0.6f;
        }
        else
        {
            physicMaterial.staticFriction = 0.3f;
        }

        playerRB.AddForce(Vector3.down * artificialGravity);
    }

    public void ResetSpawnPlayer()
    {
        //GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = new Vector3(0f, playerRB.velocity.y, 0f);
    }

    public void EnableCollider()
    {
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<MeshCollider>().enabled = false;
    }
    public void DisableCollider()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<MeshCollider>().enabled = true;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnPlaneModeChanged(GameState.PlaneMode planeMode)
    {
        canThrowBall = planeMode == GameState.PlaneMode.Ghost;
        ballPickeableGO.SetActive(planeMode == GameState.PlaneMode.Ghost);
    }
    //Comportamiento del player con la pelota y las condiciones para que reproduzca la mecanica de tirar y agarrar
    private void BallGrabAndThrow()
    {
        if (!canThrowBall)
        {
            if (ball != null)
                Destroy(ball);
            return;
        }
        if (ball == null && BallCount > 0)
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
            BallCount--;
            ballReload = 0f;
            ball.transform.parent = null;
            ball.GetComponent<Rigidbody>().isKinematic = false;
            ball.GetComponent<Rigidbody>().AddForce(hand.transform.forward * ballThrowForce, ForceMode.Impulse);
            ball.transform.GetChild(0).gameObject.SetActive(true);
            ball = null;
            Debug.Log(" A tiraR, Tengo " + BallCount + " pelotas de " + maxCapacityOfBalls);
        }
        
    }

    public bool PickupBalls(int balls)
    {
        if (BallCount >= maxCapacityOfBalls)
            return false;
        BallCount = Mathf.Min(BallCount + balls, maxCapacityOfBalls);
        return true;
        //Debug.Log(" A la agarrar, Tengo " + currBallsInHand + " pelotas de " + ballCount);
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

    void Jump()
    {
        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            float jumpvelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            playerRB.velocity = new Vector3(playerRB.velocity.x, jumpvelocity, playerRB.velocity.z);
            jumpBufferCounter = 0;
        }
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

        if(Input.GetButtonUp("Jump") && playerRB.velocity.y > 0)
        {
            print("coyote");
            coyoteTimeCounter = 0;
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

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Wheel")
        {
            print("Entre");
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Wheel")
        {
            print("Sali");
            gameObject.transform.parent = null;
        }
    }
}
