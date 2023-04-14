using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterializeObjects : MonoBehaviour
{
    [SerializeField] GameObject ruler;
    GameObject actualObject;
    [SerializeField] List<GameObject> objectsActive;
    [SerializeField] Transform spawnPos;

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
        if (Input.GetButtonDown("Action1"))
        {
            if (!placingObject)
            {
                GameObject newRuler = Instantiate(ruler, spawnPos.position, spawnPos.rotation);
                placingObject = true;
                actualObject = newRuler;
                actualObject.transform.parent = gameObject.transform;

                if (objectsActive.Count == 2)
                {
                    Destroy(objectsActive[0]);
                    objectsActive[0] = objectsActive[1];
                    objectsActive[1] = actualObject;
                }
                else
                {
                    objectsActive.Add(actualObject);
                    objectCreated++;
                }
                
            }
            else
            {
                actualObject.transform.parent = null;
                actualObject.GetComponent<Rigidbody>().isKinematic = false;
                actualObject.GetComponent<RotateObject>().enabled = false;
                placingObject = false;
            }

        }
    }
}
