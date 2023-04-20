using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float speedRotation, speedMov, sens;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject finalPosObject, actualObject;
    bool ray, destroyFinalPosObject;
    RaycastHit hit;

    public void FinalPosObject()
    {
        Destroy(actualObject);
        this.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        actualObject = Instantiate(finalPosObject, transform.position, transform.rotation);
        destroyFinalPosObject = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (destroyFinalPosObject)
        {
            Destroy(actualObject);
        }

        transform.Translate(0, Input.GetAxis("Mouse Y") * (sens * speedMov) * Time.deltaTime, 0);
        ray = Physics.BoxCast(gameObject.GetComponent<Collider>().bounds.center, transform.localScale, -transform.up, out hit, transform.rotation, 100f, layerMask);
        float rotation = Input.GetAxis("RotateObject") * speedRotation;
        gameObject.transform.Rotate(0, rotation * Time.deltaTime, 0);
        actualObject.transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        actualObject.transform.rotation = transform.rotation;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector3(transform.position.x, hit.point.y, transform.position.z), transform.localScale);
    }

}
