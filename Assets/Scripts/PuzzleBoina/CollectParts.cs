using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectParts : MonoBehaviour
{
    bool part1, part2, part3;
    PuzzleBoina puzzleBoina;
    // Start is called before the first frame update
    void Start()
    {
        puzzleBoina = GameObject.Find("PuzzleBoinaGO").GetComponent<PuzzleBoina>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectPart(int number)
    {
        if(number == 1)
        {
            part1 = true;
        }
        else if (number == 2)
        {
            part2 = true;
        }
        else if(number == 3)
        {
            part3 = true;
        }
        
        if(part1 && part2 && part3)
        {
            puzzleBoina.Colectibles = true;
        }
    }
}
