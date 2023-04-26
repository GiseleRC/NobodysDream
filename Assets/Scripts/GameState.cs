using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    [System.Serializable] public class PlaneModeChangedEvent : UnityEvent<PlaneMode> {}

    [SerializeField] PlaneModeChangedEvent OnPlaneModeChanged;
    [SerializeField] public GameObject playerSC;
    [SerializeField] public Transform playerSpawn;

    private PlaneMode planeMode = PlaneMode.Dream;
    public bool DreamPlaneModeEnabled { get; set; } = true;
    public bool GhostPlaneModeEnabled { get; set; } = false;
    public bool DemonPlaneModeEnabled { get; set; } = false;

    public enum PlaneMode
    {
        Dream,
        Ghost,
        Demon
    }

    public PlaneMode GetPlaneMode()
    {
        return planeMode;
    }

    public bool SetPlaneMode(PlaneMode planeMode)
    {
        if (planeMode == this.planeMode)
            return false;
        if (planeMode == PlaneMode.Dream && !DreamPlaneModeEnabled)
            return false;
        if (planeMode == PlaneMode.Ghost && !GhostPlaneModeEnabled)
            return false;
        if (planeMode == PlaneMode.Demon && !DemonPlaneModeEnabled)
            return false;

        this.planeMode = planeMode;
        Debug.Log("Cambiando a Plane Mode " + planeMode.ToString());

        OnPlaneModeChanged.Invoke(this.planeMode);
        return true;
    }

    public void SetNextPlaneMode()
    {
        switch (planeMode)
        {
            case PlaneMode.Dream:
                if (!SetPlaneMode(PlaneMode.Ghost))
                    SetPlaneMode(PlaneMode.Demon);
                break;
            case PlaneMode.Ghost:
                if (!SetPlaneMode(PlaneMode.Demon))
                    SetPlaneMode(PlaneMode.Dream);
                break;
            case PlaneMode.Demon:
                if (!SetPlaneMode(PlaneMode.Dream))
                    SetPlaneMode(PlaneMode.Ghost);
                break;
        }
    }

    public void SetPrevPlaneMode()
    {
        switch (planeMode)
        {
            case PlaneMode.Dream:
                if (!SetPlaneMode(PlaneMode.Demon))
                    SetPlaneMode(PlaneMode.Ghost);
                break;
            case PlaneMode.Ghost:
                if (!SetPlaneMode(PlaneMode.Dream))
                    SetPlaneMode(PlaneMode.Demon);
                break;
            case PlaneMode.Demon:
                if (!SetPlaneMode(PlaneMode.Ghost))
                    SetPlaneMode(PlaneMode.Dream);
                break;
        }
    }

    public void RespawnPlayer()
    {
        playerSC.transform.position = playerSpawn.position;
        playerSC.transform.rotation = playerSpawn.rotation;
    }
}
