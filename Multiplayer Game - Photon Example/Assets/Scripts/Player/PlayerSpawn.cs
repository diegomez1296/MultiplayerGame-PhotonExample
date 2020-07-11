using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook cameraPlayerPrefab;
    [SerializeField] private GameObject playerPrefab;

    void Start()
    {
        var player = PhotonNetwork.Instantiate(playerPrefab.name, this.transform.position, Quaternion.identity);
        cameraPlayerPrefab.Follow = player.GetComponent<PlayerMovement>().cameraPoint.transform;
        cameraPlayerPrefab.LookAt = player.GetComponent<PlayerMovement>().cameraPoint.transform;
    }
}
