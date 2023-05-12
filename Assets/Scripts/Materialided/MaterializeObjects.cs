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

    public AudioSource fallObj, spawnObj, spawnPosition;
    bool placingObject, test;
    int objectCreated;
    void Start()
    {
        objectCreated = 0;
        lastObjectCreated = ruler;
    }
    void Update()
    {
        // creo que tiemblan las posiciones de lo objetos porque 1 vez por frame esta comprobando donde ubicarse entre 2 floors
        //tal vez se podriubicar dandole un rango  de distancia y si se pasa de ese rango ubicar el pre objeto
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

        if (Input.GetButtonDown("Action1")) 
        {

            if (!placingObject) // Spawnea
            {
                spawnPosition.Play();
                newObject = Instantiate(lastObjectCreated, pos, transform.rotation);
                placingObject = true;
                actualObject = newObject;
                actualObject.transform.parent = gameObject.transform;
                actualObject.transform.eulerAngles = new Vector3(actualObject.transform.eulerAngles.x, actualObject.transform.eulerAngles.y + 90, actualObject.transform.eulerAngles.z);
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
                else //Posiciona el item
                {
                    if (cubesActive.Count == 2)
                    {
                        Destroy(cubesActive[0]);
                        cubesActive[0] = cubesActive[1];
                        cubesActive[1] = actualObject;
                        actualObject.GetComponent<Collider>().enabled = true;
                    }
                    else
                    {
                        cubesActive.Add(actualObject);
                        objectCreated++;
                        actualObject.GetComponent<Collider>().enabled = true;
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
            if (Input.GetButtonDown("SwitchItem")) //Cambia de item
            {
                if(actualObject.tag == "Ruler")
                {
                    spawnObj.Play();
                    actualObject.GetComponent<RotateObject>().CancelObject();
                    Destroy(newObject);
                    newObject = Instantiate(cube, pos, transform.rotation);
                    actualObject = newObject;
                    actualObject.transform.parent = gameObject.transform;
                }
                else
                {
                    spawnObj.Play();
                    actualObject.GetComponent<RotateObject>().CancelObject();
                    Destroy(newObject);
                    newObject = Instantiate(ruler, pos, transform.rotation);
                    actualObject = newObject;
                    actualObject.transform.parent = gameObject.transform;
                    actualObject.transform.eulerAngles = new Vector3(actualObject.transform.eulerAngles.x, actualObject.transform.eulerAngles.y + 90, actualObject.transform.eulerAngles.z);
                }
            }
            fallObj.Play();
        }

        if(Input.GetButtonDown("Cancel") && placingObject) //Cancela
        {
            actualObject.GetComponent<RotateObject>().CancelObject();
            placingObject = false;
        }

        //print(hit.collider);
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