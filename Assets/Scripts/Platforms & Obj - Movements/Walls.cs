using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] private GameObject[] walls;
    private Vector3[] wallsRestorePos;
    public AudioSource AmbientSound, FallingWalls;
    [SerializeField] private GameObject sensor;
    private float waitFor = 5f;

    private void Start()
    {
        wallsRestorePos = new Vector3[walls.Length];
        for (int i = 0; i < walls.Length; i++)
        {
            wallsRestorePos[i] = walls[i].transform.localPosition;
        }
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            if (walls[i].transform.localPosition.y < -40)
            {
                walls[i].SetActive(false);
            }
        }
    }
    public void EventDropWalls()
    {
        DropWalls();
    }
    public void EventRestoreWalls()
    {
        RestoreWalls();
    }
    
    private void DropWalls()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].GetComponent<Rigidbody>().isKinematic = false;
        }
        AmbientSound.Play();
        FallingWalls.Play();
        sensor.SetActive(false);
    }
    private void RestoreWalls()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].SetActive(true);
            walls[i].GetComponent<Rigidbody>().isKinematic = true;
            walls[i].transform.localPosition = wallsRestorePos[i];
        }
    }
}
