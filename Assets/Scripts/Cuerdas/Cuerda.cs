using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda : MonoBehaviour
{
    [SerializeField] Rigidbody rbBalanza;
    [SerializeField] PuzzleEnderezarPlataforma puzzleEnderezarPlataforma;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    private void OnDestroy()
    {
        if(rbBalanza != null)
        {
            rbBalanza.isKinematic = false;
        }

        if(puzzleEnderezarPlataforma != null)
        {
            puzzleEnderezarPlataforma.cutRope = true;
        }

    }
}
