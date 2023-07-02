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
        if(other.gameObject.name == "Char")
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Check")
        {
            color = "Check" + color;

            if(color == other.gameObject.name)
            {
                print("correcto");
                Destroy(gameObject);
            }
            else
            {
                gameObject.transform.parent = null;
                print("Incorrecto");
            }
        }
    }
}
