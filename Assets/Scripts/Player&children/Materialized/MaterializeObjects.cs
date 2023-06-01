using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterializeObjects : MonoBehaviour
{
    [SerializeField] GameObject ruler,cube, camPos;
    [SerializeField] List<GameObject> rulersActive, cubesActive;
    GameObject actualObject, lastObjectCreated, newObject;
    [SerializeField] LayerMask layerMask;
    public bool materializanding = false;
    Vector3 pos;

    public AudioSource fallObj, spawnObj, spawnPosition;
    bool placingObject, test;
    int objectCreated;

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
        objectCreated = 0;
        lastObjectCreated = ruler;
    }
    void Update()
    {
        RaycastHit hit;

        bool ray = Physics.Raycast(camPos.transform.position, camPos.transform.forward, out hit, 3f, layerMask);

        if (ray)
        {
            pos = hit.point;
        }
        else
        {
            pos = camPos.transform.position + camPos.transform.forward * 3f;
        }

        if (Input.GetButtonDown("RightClick")) 
        {
            materializanding = true;
            if (!placingObject) // Spawnea
            {
                PrevSpawn();
            }
            else
            {
                PlaceObject();
                materializanding = false;
            }
        }

        if (placingObject)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll > 0f)
            {
                SwitchItem();
            }
            else if (scroll < 0f)
            {
                SwitchItem();
            }
            fallObj.Play();
        }

        if(Input.GetButtonDown("CancelMat") && placingObject) //Cancela
        {
            CancelObject();
            materializanding = false;
        }
        else if (Input.GetButtonDown("CancelMat"))
        {
            materializanding = false;
        }
    }

    public Vector3 PosObject
    {
        get
        {
            return pos;
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawRay(camPos.transform.position, camPos.transform.forward.normalized * 6f);
    }*/

    void PrevSpawn()
    {
        spawnPosition.Play();
        newObject = Instantiate(lastObjectCreated, pos, transform.rotation);
        placingObject = true;
        actualObject = newObject;
        actualObject.transform.parent = gameObject.transform;
        actualObject.transform.eulerAngles = new Vector3(actualObject.transform.eulerAngles.x, actualObject.transform.eulerAngles.y + 90, actualObject.transform.eulerAngles.z);
    }

    void PlaceObject()
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
        if (actualObject.GetComponent<Collider>() != null)
        {
            actualObject.GetComponent<Collider>().isTrigger = false;
        }
        else
        {
            actualObject.GetComponentInChildren<Collider>().isTrigger = false;
        }
        actualObject.transform.position = ro.FinalPos;
        actualObject.GetComponent<RotateObject>().FinalPosObject();
        //actualObject.GetComponent<RotateObject>().Spawn();
        placingObject = false;
    }

    void SwitchItem()
    {
        if (actualObject.tag == "Ruler")
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

    void CancelObject()
    {
        actualObject.GetComponent<RotateObject>().CancelObject();
        placingObject = false;
        materializanding = false;
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}