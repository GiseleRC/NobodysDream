using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBoina : MonoBehaviour
{
    [SerializeField]GameObject part1, part2, part3;
    [SerializeField] Transform finalPos1, finalPos2, finalPos3;
    [SerializeField] float speed;
    bool playerIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn)
        {
            part1.transform.position = Vector3.Lerp(part1.transform.position, finalPos1.position, speed * Time.deltaTime);
            part2.transform.position = Vector3.Lerp(part2.transform.position, finalPos2.position, speed * Time.deltaTime);
            part3.transform.position = Vector3.Lerp(part3.transform.position, finalPos3.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Char")
        {
            playerIn = true;
            Instantiate(part1, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z + 3f), other.gameObject.transform.rotation); ;
        }
    }
}
