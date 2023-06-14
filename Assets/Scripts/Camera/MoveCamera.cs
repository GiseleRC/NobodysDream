using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Transform cameraPos;
    float timer, defaultPosY, defaultPosX;
    [SerializeField] float boobingSpeed, bobbingAmount;
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
        cameraPos = GameObject.Find("cameraPos").GetComponent<Transform>();
        defaultPosY = cameraPos.transform.localPosition.y;
        defaultPosX = cameraPos.transform.localPosition.x;
        transform.position = cameraPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        if (inputX != 0 || inputY != 0)
        {
            timer += Time.deltaTime * boobingSpeed;
            cameraPos.transform.localPosition = new Vector3(cameraPos.transform.localPosition.x + Mathf.Cos(timer) * bobbingAmount * Time.deltaTime, cameraPos.transform.localPosition.y + Mathf.Cos(timer) * bobbingAmount * Time.deltaTime, cameraPos.transform.localPosition.z);
        }
        else
        {
            cameraPos.transform.localPosition = new Vector3(Mathf.Lerp(cameraPos.transform.localPosition.x, defaultPosX, Time.deltaTime * boobingSpeed), Mathf.Lerp(cameraPos.transform.localPosition.y, defaultPosY, Time.deltaTime * boobingSpeed), cameraPos.localPosition.z);

        }

        transform.position = cameraPos.transform.position;
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}
