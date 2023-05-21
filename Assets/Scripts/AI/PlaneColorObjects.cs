using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColorObjects : MonoBehaviour
{
    private Color colorDreamPlane;
    public GameObject particles;
    [SerializeField] private Color colorGhostPlane;
    [SerializeField] private Color colorDemonPlane;

    void Awake()
    {
        colorDreamPlane = GetComponentInChildren<Renderer>().material.color;
    }
    public void OnPlaneModeChanged(GameState.PlaneMode planeMode)
    {
        switch (planeMode)
        {
            case GameState.PlaneMode.Dream:
                particles.SetActive(false);
                foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
                    renderer.material.color = colorDreamPlane;
                break;
            case GameState.PlaneMode.Ghost:
                particles.SetActive(true);
                foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
                    renderer.material.color = colorGhostPlane;
                break;
            case GameState.PlaneMode.Demon:
                foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
                    renderer.material.color = colorDemonPlane;
                break;
        }
    }
}
