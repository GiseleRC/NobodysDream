using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    Rigidbody rb;

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
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (destroyFinalPosObject)
        {
            Destroy(actualObject);
        }

        transform.position = mo.PosObject;
        Collider[] col = Physics.OverlapBox(gameObject.GetComponent<Collider>().bounds.center, transform.localScale, transform.rotation, layerMask);
        Collider[] orderCol;
        Vector3 closestPoint;

        if (col.Any())
        {
            orderCol = col.OrderBy(x => Vector3.Distance(x.transform.position, mo.PosObject)).ToArray();
            closestPoint = orderCol[0].ClosestPoint(mo.PosObject);
        }
        else if(Physics.Raycast(transform.position,-Vector3.up, out hit, Mathf.Infinity,layerMask))
        {
            closestPoint = hit.point;
        }
        else
        {
            closestPoint = mo.transform.position;
        }

        float rotation = Input.GetAxis("RotateObject") * speedRotation;
        gameObject.transform.Rotate(0, rotation * Time.deltaTime, 0);

        if (cube)
        {
            //actualObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            actualObject.transform.position = new Vector3(transform.position.x, closestPoint.y + 0.5f, transform.position.z);
        }
        else
        {
            //actualObject.transform.position = transform.position;
            actualObject.transform.position = new Vector3(transform.position.x, closestPoint.y, transform.position.z);
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

    public void Spawn()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        StartCoroutine(WaitPhysics());
    }

    IEnumerator WaitPhysics()
    {
        yield return new WaitForSeconds(0.5f);

        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.isKinematic = true;
    }

}
