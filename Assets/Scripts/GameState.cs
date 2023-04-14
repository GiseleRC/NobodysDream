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
        if (planeMode == this.planeMode)
            return;

        this.planeMode = planeMode;
        Debug.Log("Cambiando a Plane Mode " + planeMode.ToString());
    }

    public void SetNextPlaneMode()
    {
        switch (planeMode)
        {
            case PlaneMode.Dream:
                SetPlaneMode(PlaneMode.Ghost);
                break;
            case PlaneMode.Ghost:
                SetPlaneMode(PlaneMode.Demon);
                break;
            case PlaneMode.Demon:
                SetPlaneMode(PlaneMode.Dream);
                break;
        }
    }

    public void SetPrevPlaneMode()
    {
        switch (planeMode)
        {
            case PlaneMode.Dream:
                SetPlaneMode(PlaneMode.Demon);
                break;
            case PlaneMode.Ghost:
                SetPlaneMode(PlaneMode.Dream);
                break;
            case PlaneMode.Demon:
                SetPlaneMode(PlaneMode.Ghost);
                break;
        }
    }

    private PlaneMode planeMode = PlaneMode.Dream;
}
