using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField] int partNumber;
    PuzzleBoina puzzleBoina;
    [SerializeField] string color;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("PuzzleBoinaGO") != null)
            puzzleBoina = GameObject.Find("PuzzleBoinaGO").GetComponent<PuzzleBoina>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        if(GameObject.Find("PuzzleBoina") != null)
            GameObject.Find("PuzzleBoina").GetComponent<CollectParts>().CollectPart(partNumber);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Char" && puzzleBoina.playerIn == false)
        {
            if(puzzleBoina.playerIn == true)
            {
                gameObject.transform.parent = null;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if(other.gameObject.tag == "Check")
        {
            color = color + "Frame";

            if(color == other.gameObject.name)
            {
                print("correcto");
                gameObject.transform.position = other.gameObject.transform.position;
            }
            else
            {
                print("Entre");
                gameObject.transform.parent = null;
                puzzleBoina.Incorrect(color);
            }
        }
    }
}
