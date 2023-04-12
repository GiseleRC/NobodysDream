using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Transform cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = GameObject.Find("cameraPos").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = cameraPos.position;
    }
}
