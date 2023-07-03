using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBoina : MonoBehaviour
{
    [SerializeField] GameObject part1, part2, part3, character;
    [SerializeField] Transform finalPos1, finalPos2, finalPos3;
    [SerializeField] float speed;
    float distance1, distance2, distance3;
    int count;
    bool move1, move2, move3;
    public bool playerIn;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Char");
    }

    // Update is called once per frame
    void Update()
    {
        distance1 = Vector3.Distance(part1.transform.position, finalPos1.transform.position);
        distance2 = Vector3.Distance(part2.transform.position, finalPos2.transform.position);
        distance3 = Vector3.Distance(part3.transform.position, finalPos3.transform.position);

        if (playerIn && count == 0)
        {
            part1.transform.position = Vector3.Lerp(part1.transform.position, finalPos1.position, speed * Time.deltaTime);
            //part1.transform.rotation = finalPos1.transform.rotation;
            part2.transform.position = Vector3.Lerp(part2.transform.position, finalPos2.position, speed * Time.deltaTime);
            //part2.transform.rotation = finalPos2.transform.rotation;
            part3.transform.position = Vector3.Lerp(part3.transform.position, finalPos3.position, speed * Time.deltaTime);
            //part3.transform.rotation = finalPos3.transform.rotation;

            
            if (distance1 < 0.3f && distance2 < 0.3f && distance3 < 0.3f)
            {
                count = 1;
            }
        }

        if(count == 1)
        {
            if(move1 == true)
            {
                part1.transform.position = Vector3.Lerp(part1.transform.position, finalPos1.transform.position, speed * Time.deltaTime);

                if(distance1 < 0.3f)
                {
                    move1 = false;
                }
            }

            if(move2 == true)
            {
                part2.transform.position = Vector3.Lerp(part2.transform.position, finalPos2.transform.position, speed * Time.deltaTime);

                if (distance2 < 0.3f)
                {
                    move2 = false;
                }
            }

            if(move3 == true)
            {
                part3.transform.position = Vector3.Lerp(part3.transform.position, finalPos3.transform.position, speed * Time.deltaTime);

                if (distance3 < 0.3f)
                {
                    move3 = false;
                }
            }


        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Char" && !playerIn && count == 0)
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

    public void Incorrect(string color)
    {
        if(color == "YellowFrame")
        {
            move1 = true;
        }
        else if(color == "RedFrame")
        {
            move2 = true;
        }
        else if(color == "BlueFrame")
        {
            move3 = true;
        }
    }
}
