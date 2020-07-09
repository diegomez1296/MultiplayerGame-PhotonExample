using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviourPun
{
    private CharacterController characterController;
    [SerializeField] private float playerSpeed = 5;

    void Start() => characterController = GetComponent<CharacterController>();

    void Update()
    {
        if (photonView.IsMine)
        {
            GetInput();
        }
    }

    private void GetInput()
    {
        Vector3 position = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.SimpleMove(position.normalized * playerSpeed);
    }
}
