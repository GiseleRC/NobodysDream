using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointVFX : MonoBehaviour
{
    [SerializeField] GameObject torch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        torch.GetComponent<EnableFireTorch>().PlayFire();
    }
}
