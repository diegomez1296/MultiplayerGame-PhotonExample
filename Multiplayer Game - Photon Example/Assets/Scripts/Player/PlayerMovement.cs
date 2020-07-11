using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviourPun
{
    public GameObject cameraPoint;

    private CharacterController characterController;
    private Transform mainCameraTransform;
    [SerializeField] private float playerSpeed = 5;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCameraTransform = Camera.main.transform;
    }

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

        Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 calculateedMovement = (forward * position.normalized.z + right * position.normalized.x).normalized;

        if(calculateedMovement != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(calculateedMovement);

        characterController.SimpleMove(calculateedMovement * playerSpeed);
    }
}
