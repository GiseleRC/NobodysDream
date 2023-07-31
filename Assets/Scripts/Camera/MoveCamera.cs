using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Transform cameraPos, initialCameraPos, crouchCameraPos, armsInitial, armsCrouch;
    GameObject arms;
    float timer, defaultPosY, defaultPosX, defaultPosYInitialPos, defaultPosXInitialPos, defaultCrouchPosYInitialPos, defaultCrouchPosXInitialPos;
    [SerializeField] float boobingSpeed, bobbingAmount;
    PlayerSC playerSC;
    // Start is called before the first frame update

    private void Awake()
    {
        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }

    void Start()
    {
        armsInitial = GameObject.Find("InitialArmsPos").GetComponent<Transform>();
        armsCrouch = GameObject.Find("ArmsCrouchPos").GetComponent<Transform>();
        arms = GameObject.Find("rootLantern");
        playerSC = GameObject.Find("Char").GetComponent<PlayerSC>();
        cameraPos = GameObject.Find("cameraPos").GetComponent<Transform>();
        initialCameraPos = cameraPos;
        crouchCameraPos = GameObject.Find("CrouchCameraPos").GetComponent<Transform>();
        defaultPosYInitialPos = cameraPos.transform.localPosition.y;
        defaultPosXInitialPos = cameraPos.transform.localPosition.x;
        defaultCrouchPosYInitialPos = crouchCameraPos.transform.localPosition.y;
        defaultCrouchPosXInitialPos = crouchCameraPos.transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        if(playerSC.IsCrouch == false)
        {
            arms.transform.position = Vector3.Lerp(arms.transform.position, armsInitial.transform.position, 1f);
            transform.position = Vector3.Lerp(transform.position, initialCameraPos.position,1f);
            defaultPosX = defaultPosXInitialPos;
            defaultPosY = defaultPosYInitialPos;
            cameraPos = initialCameraPos;

        }

        if(playerSC.IsCrouch == true)
        {
            arms.transform.position = Vector3.Lerp(arms.transform.position, armsCrouch.transform.position, 1f);
            transform.position = Vector3.Lerp(transform.position, crouchCameraPos.position,1f);
            defaultPosX = defaultCrouchPosXInitialPos;
            defaultPosY = defaultCrouchPosYInitialPos;
            cameraPos = crouchCameraPos;
        }

        if (inputX != 0 || inputY != 0)
        {
            timer += Time.deltaTime * boobingSpeed;
            cameraPos.transform.localPosition = new Vector3(cameraPos.transform.localPosition.x + Mathf.Cos(timer) * bobbingAmount * Time.deltaTime, cameraPos.transform.localPosition.y + Mathf.Cos(timer) * bobbingAmount * Time.deltaTime, cameraPos.transform.localPosition.z);
        }
        else
        {
            cameraPos.transform.localPosition = new Vector3(Mathf.Lerp(cameraPos.transform.localPosition.x, defaultPosX, Time.deltaTime * boobingSpeed), Mathf.Lerp(cameraPos.transform.localPosition.y, defaultPosY, Time.deltaTime * boobingSpeed), cameraPos.localPosition.z);
        }

    }

    private void LateUpdate()
    {

    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}
