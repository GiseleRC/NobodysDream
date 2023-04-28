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
    [SerializeField] public Transform point1;
    [SerializeField] public Transform point2;
    [SerializeField] public Transform point3;
    [SerializeField] public Transform inicialPos;
    [SerializeField] private float dreamPlaneTimeScale = 1f;
    [SerializeField] private float ghostPlaneTimeScale = 1f;
    [SerializeField] private float demonPlaneTimeScale = 1f;

    public PlaneMode planeMode = PlaneMode.Dream;
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

        switch (planeMode)
        {
            case PlaneMode.Dream:
                Time.timeScale = dreamPlaneTimeScale;
                break;
            case PlaneMode.Ghost:
                Time.timeScale = ghostPlaneTimeScale;
                break;
            case PlaneMode.Demon:
                Time.timeScale = demonPlaneTimeScale;
                break;
        }
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

    public void PositionInitial()
    {
        playerSpawn.transform.position = inicialPos.position;
        playerSpawn.transform.rotation = inicialPos.rotation;
    }

    public void Position1()
    {
        playerSpawn.transform.position = point1.position;
        playerSpawn.transform.rotation = point1.rotation;
    }
    public void Position2()
    {
        playerSpawn.transform.position = point2.position;
        playerSpawn.transform.rotation = point2.rotation;
    }
    public void Position3()
    {
        playerSpawn.transform.position = point3.position;
        playerSpawn.transform.rotation = point3.rotation;
    }
    public void RespawnPlayer()
    {
        playerSC.transform.position = playerSpawn.position;
        playerSC.transform.rotation = playerSpawn.rotation;
    }
}
