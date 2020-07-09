using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerManager : MonoBehaviourPunCallbacks
{
    private bool isConnecting = false;

    private void Awake() => PhotonNetwork.AutomaticallySyncScene = true;

    public void FindServer()
    {
        isConnecting = true;

        MenuCanvas.Instance.SetConsoleText(ServerConstants.MSG_SEARCHING);

        if (PhotonNetwork.IsConnected) 
            PhotonNetwork.JoinRandomRoom();
        else
        {
            PhotonNetwork.GameVersion = ServerConstants.GAME_VERSION;
            PhotonNetwork.ConnectUsingSettings();
        }

    }

    public override void OnConnected()
    {
        base.OnConnected();
    }

    public override void OnConnectedToMaster()
    {
        if(isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
    }

    public override void OnCustomAuthenticationFailed(string debugMessage)
    {
        base.OnCustomAuthenticationFailed(debugMessage);
    }

    public override void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {
        base.OnCustomAuthenticationResponse(data);
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        MenuCanvas.Instance.SetConsoleText("Disconnected due to: " + cause);
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnErrorInfo(ErrorInfo errorInfo)
    {
        base.OnErrorInfo(errorInfo);
    }

    public override void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        base.OnFriendListUpdate(friendList);
    }

    public override void OnJoinedLobby()
    {

    }

    public override void OnJoinedRoom()
    {

        Debug.Log("Joined to room");

        if (PhotonNetwork.CurrentRoom.PlayerCount < ServerConstants.MIN_PLAYERS_IN_ROOM)
        {
            MenuCanvas.Instance.SetConsoleText(ServerConstants.MSG_WAITING);
        }
        else
        {
            MenuCanvas.Instance.SetConsoleText(ServerConstants.MSG_READY);
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Creating a new room...");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = ServerConstants.MAX_PLAYERS_IN_ROOM });
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
    }

    public override void OnLeftLobby()
    {
        base.OnLeftLobby();
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
    }

    public override void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
    {
        base.OnLobbyStatisticsUpdate(lobbyStatistics);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        base.OnMasterClientSwitched(newMasterClient);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Entered to room");

        if (PhotonNetwork.CurrentRoom.PlayerCount >= ServerConstants.MAX_PLAYERS_IN_ROOM)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }

        if (PhotonNetwork.CurrentRoom.PlayerCount >= ServerConstants.MIN_PLAYERS_IN_ROOM)
        {
            PhotonNetwork.LoadLevel(2);
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
    }

    public override void OnRegionListReceived(RegionHandler regionHandler)
    {
        base.OnRegionListReceived(regionHandler);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        base.OnRoomPropertiesUpdate(propertiesThatChanged);
    }

    public override void OnWebRpcResponse(OperationResponse response)
    {
        base.OnWebRpcResponse(response);
    }
}
