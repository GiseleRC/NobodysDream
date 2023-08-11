using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMemory : MonoBehaviour
{
    public void StartMemoryGame()
    {
        GetComponent<PuzzleMemory>().enabled = true;
    }
}
