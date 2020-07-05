using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public GameData Data { get; private set; }
    public ServerManager Server { get; private set; }

    private void Awake() => Instance = this;

    private void Start()
    {
        Data = GetComponentInChildren<GameData>();
        Server = GetComponentInChildren<ServerManager>();
        DontDestroyOnLoad(this);
        SceneManager.LoadSceneAsync(1);
    }
}
