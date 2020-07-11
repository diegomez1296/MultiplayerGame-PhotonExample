using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTag : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI nickText;
    private Transform mainCameraTransform;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;

        if (photonView.IsMine) return;

        SetNickText();
    }

    private void LateUpdate()
    {
        nickText.transform.LookAt(nickText.transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
    }

    private void SetNickText()
    {
        nickText.text = photonView.Owner.NickName;
    }
}
