using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    public static MenuCanvas Instance;

    private CharacterSelect characterSelect;
    private TMP_InputField inputField;
    private ConsoleOutput console;

    private void Awake() => Instance = this;

    private void Start()
    {
        characterSelect = GetComponentInChildren<CharacterSelect>();
        inputField = GetComponentInChildren<TMP_InputField>();
        console = GetComponentInChildren<ConsoleOutput>();

        characterSelect.CreateList(GameController.Instance.Data.characterPlayers);
    }

    public void SetConsoleText(string text, float time = 0)
    {
        console.SetText(text, time);
    }

    public void OnContinueClick()
    {
        if(string.IsNullOrEmpty(inputField.text))
        {
            console.SetText("Nickname cannot be empty");
            return;
        }

        PhotonNetwork.NickName = inputField.text;
        GameController.Instance.Server.FindServer();
    }



    
}
