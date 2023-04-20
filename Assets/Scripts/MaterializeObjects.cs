using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterializeObjects : MonoBehaviour
{
    [SerializeField] GameObject ruler,cube, camPos;
    [SerializeField] List<GameObject> rulersActive, cubesActive;
    GameObject actualObject;


    bool placingObject;
    int objectCreated;
    // Start is called before the first frame update
    void Start()
    {
        objectCreated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        bool ray = Physics.Raycast(camPos.transform.position, camPos.transform.forward, out hit, 6f);

        var pos = camPos.transform.position + camPos.transform.forward.normalized * 6f;

        if (Input.GetButtonDown("Action1"))
        {
            if (!placingObject)
            {
                GameObject newRuler = Instantiate(ruler, pos, transform.rotation);
                placingObject = true;
                actualObject = newRuler;
                actualObject.transform.parent = gameObject.transform;

                if (rulersActive.Count == 2)
                {
                    Destroy(rulersActive[0]);
                    rulersActive[0] = rulersActive[1];
                    rulersActive[1] = actualObject;
                }
                else
                {
                    rulersActive.Add(actualObject);
                    objectCreated++;
                }

            }
            else
            {
                actualObject.transform.parent = null;
                actualObject.GetComponent<Rigidbody>().isKinematic = false;
                actualObject.GetComponent<RotateObject>().FinalPosObject();
                placingObject = false;

            }

        }

        if (Input.GetButtonDown("Action2"))
        {
            if (!placingObject)
            {
                GameObject newCube = Instantiate(cube, pos, transform.rotation);
                placingObject = true;
                actualObject = newCube;
                actualObject.transform.parent = gameObject.transform;

                if (cubesActive.Count == 2)
                {
                    Destroy(cubesActive[0]);
                    cubesActive[0] = cubesActive[1];
                    cubesActive[1] = actualObject;
                }
                else
                {
                    cubesActive.Add(actualObject);
                    objectCreated++;
                }

            }
            else
            {
                actualObject.transform.parent = null;
                actualObject.GetComponent<Rigidbody>().isKinematic = false;
                actualObject.GetComponent<RotateObject>().FinalPosObject();
                placingObject = false;

            }

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(camPos.transform.position, camPos.transform.forward * 6f);
    }
}