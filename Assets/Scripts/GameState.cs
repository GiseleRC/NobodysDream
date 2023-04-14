using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum PlaneMode
    {
        Dream,
        Ghost,
        Demon
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlaneMode GetPlaneMode()
    {
        return planeMode;
    }

    public void SetPlaneMode(PlaneMode planeMode)
    {
        this.planeMode = planeMode;
    }

    public void SetNextPlaneMode()
    {
        switch (planeMode)
        {
            case PlaneMode.Dream:
                planeMode = PlaneMode.Ghost;
                break;
            case PlaneMode.Ghost:
                planeMode = PlaneMode.Demon;
                break;
            case PlaneMode.Demon:
                planeMode = PlaneMode.Dream;
                break;
        }
    }

    public void SetPrevPlaneMode()
    {
        switch (planeMode)
        {
            case PlaneMode.Dream:
                planeMode = PlaneMode.Demon;
                break;
            case PlaneMode.Ghost:
                planeMode = PlaneMode.Dream;
                break;
            case PlaneMode.Demon:
                planeMode = PlaneMode.Ghost;
                break;
        }
    }

    private PlaneMode planeMode = PlaneMode.Dream;
}
