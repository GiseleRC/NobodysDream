using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBoina : MonoBehaviour
{
    [SerializeField]GameObject part1, part2, part3, character;
    [SerializeField] Transform finalPos1, finalPos2, finalPos3;
    [SerializeField] float speed;
    public bool playerIn;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Char");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn)
        {
            part1.transform.position = Vector3.Lerp(part1.transform.position, finalPos1.position, speed * Time.deltaTime);
            part2.transform.position = Vector3.Lerp(part2.transform.position, finalPos2.position, speed * Time.deltaTime);
            part3.transform.position = Vector3.Lerp(part3.transform.position, finalPos3.position, speed * Time.deltaTime);

            float distance1 = Vector3.Distance(part1.transform.position, finalPos1.transform.position);
            float distance2 = Vector3.Distance(part2.transform.position, finalPos2.transform.position);
            float distance3 = Vector3.Distance(part3.transform.position, finalPos3.transform.position);
            if (distance1 < 0.3f && distance2 < 0.3f && distance3 < 0.3f)
            {
                print("Listo");
                playerIn = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Char" && !playerIn)
        {
            playerIn = true;
            part1.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 2f, character.transform.position.z);
            part2.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 2f, character.transform.position.z);
            part3.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 2f, character.transform.position.z);
            part1.GetComponentInChildren<MeshRenderer>().enabled = true;
            part2.GetComponentInChildren<MeshRenderer>().enabled = true;
            part3.GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }
}
