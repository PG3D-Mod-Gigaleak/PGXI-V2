using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;

public class LobbyKiller : Photon.PunBehaviour
{
    private bool disconnecting, joining, connected, connectedFirstTime;

    private ConnectSceneNGUIController.RegimGame regim;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {

        ConnectSceneNGUIController connectSceneNGUI = FindObjectOfType<ConnectSceneNGUIController>();

        Debug.LogError($"disconnecting {disconnecting}, joining {joining}, connected {connected}, connectedFirstTime {connectedFirstTime}, regim {regim}, connectScene {connectSceneNGUI != null}");

        if (connectSceneNGUI != null && !disconnecting)
        {
            if (!connected && !connectedFirstTime)
            {

                PhotonNetwork.ConnectUsingSettings(Initializer.Separator + regim.ToString() + 1 + "v" + GlobalGameController.MultiplayerProtocolVersion);

                connectedFirstTime = true;
                connected = true;
                
                return;
            }

            if (!PhotonNetwork.inRoom && !joining && connected)
            {
                RoomInfo[] roomList = PhotonNetwork.GetRoomList();

                if (roomList.Length > 0)
                {
                    joining = true;
                    connectSceneNGUI.JoinToRoomPhoton(roomList[0]);
                }
                else
                {
                    disconnecting = true;
                    connected = false;

                    PhotonNetwork.Disconnect();
                }
            }
        }
    }

    public override void OnDisconnectedFromPhoton()
    {
        PhotonNetwork.ConnectUsingSettings(Initializer.Separator + regim++.ToString() + 1 + "v" + GlobalGameController.MultiplayerProtocolVersion);

        if (regim == ConnectSceneNGUIController.RegimGame.Duel)
        {
            regim = ConnectSceneNGUIController.RegimGame.Deathmatch;
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        disconnecting = false;
        connected = true;
    }

    public override void OnJoinedRoom()
    {
        joining = false;
        PhotonNetwork.SetMasterClient(PhotonNetwork.player);
    }

    public override void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        PhotonNetwork.DestroyAll();

        foreach (PhotonPlayer player in PhotonNetwork.playerList)
        {
            PhotonNetwork.CloseConnection(player);
        }

        Invoke("Leave", 0.1f);
    }

    private void Leave()
    {
        Defs.typeDisconnectGame = Defs.DisconectGameType.Exit;
		PhotonNetwork.Disconnect();
    }
}
