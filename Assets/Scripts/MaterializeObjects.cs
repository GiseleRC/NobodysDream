using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterializeObjects : MonoBehaviour
{
    [SerializeField] GameObject ruler,cube, camPos;
    [SerializeField] List<GameObject> rulersActive, cubesActive;
    GameObject actualObject, lastObjectCreated, newObject;
    [SerializeField] LayerMask layerMask;
    Vector3 pos;


    bool placingObject, test;
    int objectCreated;
    // Start is called before the first frame update
    void Start()
    {
        objectCreated = 0;
        lastObjectCreated = ruler;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        bool ray = Physics.Raycast(camPos.transform.position, camPos.transform.forward, out hit, 6f, layerMask);

        if (ray)
        {
            pos = hit.point;
        }
        else
        {
            pos = camPos.transform.position + camPos.transform.forward * 6f;
        }

        print(hit.point);

        if (Input.GetButtonDown("Action1"))
        {
            if (!placingObject)
            {
                newObject = Instantiate(lastObjectCreated, pos, transform.rotation);
                placingObject = true;
                actualObject = newObject;
                actualObject.transform.parent = gameObject.transform;
                print(actualObject.name);
            }
            else
            {
                if (actualObject.tag == "Ruler")
                {
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
                    lastObjectCreated = ruler;
                }
                else
                {
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
                    lastObjectCreated = cube;
                }

                RotateObject ro;
                ro = actualObject.GetComponent<RotateObject>();
                actualObject.transform.parent = null;
                actualObject.GetComponent<Collider>().isTrigger = false;
                actualObject.transform.position = ro.FinalPos;
                actualObject.GetComponent<RotateObject>().FinalPosObject();
                actualObject.GetComponent<RotateObject>().Spawn();
                placingObject = false;

            }
        }

        if (placingObject)
        {
            if (Input.GetButtonDown("SwitchItem"))
            {
                if(actualObject.tag == "Ruler")
                {
                    actualObject.GetComponent<RotateObject>().CancelObject();
                    Destroy(newObject);
                    newObject = Instantiate(cube, pos, transform.rotation);
                    actualObject = newObject;

                }
                else
                {
                    actualObject.GetComponent<RotateObject>().CancelObject();
                    Destroy(newObject);
                    newObject = Instantiate(ruler, pos, transform.rotation);
                    actualObject = newObject;
                }
            }
            
        }

        if(Input.GetButtonDown("Cancel") && placingObject)
        {
            actualObject.GetComponent<RotateObject>().CancelObject();
            placingObject = false;
        }

        print(hit.collider);
    }

    public Vector3 PosObject
    {
        get
        {
            return pos;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(camPos.transform.position, camPos.transform.forward.normalized * 6f);
    }
}