using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float speedRotation;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject finalPosObject, actualObject;
    [SerializeField] bool cube;
    Vector3 finalPos;
    bool ray, destroyFinalPosObject;
    RaycastHit hit;
    MaterializeObjects mo;

    public void FinalPosObject()
    {
        if(gameObject.GetComponent<MeshRenderer>() != null)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        Destroy(actualObject);
        this.enabled = false;
    }

    public void CancelObject()
    {
        Destroy(actualObject);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        actualObject = Instantiate(finalPosObject, transform.position,transform.rotation);
        destroyFinalPosObject = false;
        mo = GameObject.Find("Char").GetComponent<MaterializeObjects>();

    }

    // Update is called once per frame
    void Update()
    {
        if (destroyFinalPosObject)
        {
            Destroy(actualObject);
        }

        transform.position = mo.PosObject;
        ray = Physics.BoxCast(gameObject.GetComponent<Collider>().bounds.center, transform.localScale, -transform.up, out hit, transform.rotation, 100f, layerMask);
        float rotation = Input.GetAxis("RotateObject") * speedRotation;
        gameObject.transform.Rotate(0, rotation * Time.deltaTime, 0);

        if (cube)
        {
            actualObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        }
        else
        {
            actualObject.transform.position = transform.position;
        }

        actualObject.transform.rotation = transform.rotation;

        finalPos = actualObject.transform.position;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector3(actualObject.transform.position.x, hit.point.y, actualObject.transform.position.z), transform.localScale);
        Gizmos.DrawRay(actualObject.transform.position, -transform.up);
    }

    public Vector3 FinalPos
    {
        get
        {
            return finalPos;
        }
    }

}
