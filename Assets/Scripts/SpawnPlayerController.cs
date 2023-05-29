using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnPlayerController : MonoBehaviour
{
    [SerializeField] public GameObject playerGO;
    [SerializeField] public Transform playerSpawn;
    [SerializeField] public Transform initialPos;
    private float maxDistanceY = -35f;
    void Update()
    {
        if (playerGO.transform.position.y <= maxDistanceY)
        {
            RespawnPlayer();
            playerGO.GetComponent<PlayerSC>().ResetSpawnPlayer();
        }
    }
    public void InitialPosition()
    {
        playerSpawn.transform.position = initialPos.position;
        playerSpawn.transform.rotation = initialPos.rotation;
    }
    public void Respawn(Transform transform)
    {
        playerSpawn.transform.position = transform.position;
        playerSpawn.transform.rotation = transform.rotation;
    }
    public void RespawnPlayer()
    {
        playerGO.transform.position = playerSpawn.position;
        playerGO.transform.rotation = playerSpawn.rotation;
    }
}
