using System;
using UnityEngine;

/// <summary>
/// Compatibility stubs for Unity's removed legacy networking API.
///
/// This project now uses Photon for multiplayer. These types exist only to let
/// old Unity 2017 LAN-networking branches compile in Unity 6. They do not
/// implement real networking behavior.
/// </summary>
public enum RPCMode
{
    Server,
    Others,
    OthersBuffered,
    All,
    AllBuffered
}

public enum NetworkConnectionError
{
    NoError,
    RSAPublicKeyMismatch,
    InvalidPassword,
    ConnectionFailed,
    TooManyConnectedPlayers,
    ConnectionBanned,
    AlreadyConnectedToServer,
    AlreadyConnectedToAnotherServer,
    CreateSocketOrThreadFailure,
    IncorrectParameters,
    EmptyConnectTarget,
    InternalDirectConnectFailed,
    NATTargetNotConnected,
    NATPunchthroughFailed
}

public enum NetworkDisconnection
{
    LostConnection,
    Disconnected
}

public enum NetworkStateSynchronization
{
    Off,
    ReliableDeltaCompressed,
    Unreliable,
    UnreliableOnChange
}

[Serializable]
public sealed class HostData
{
    public bool useNat;
    public string gameType = string.Empty;
    public string gameName = string.Empty;
    public int connectedPlayers;
    public int playerLimit;
    public string[] ip = new string[0];
    public int port;
    public bool passwordProtected;
    public string comment = string.Empty;
    public string guid = string.Empty;
}

[Serializable]
public struct NetworkViewID : IEquatable<NetworkViewID>
{
    private int id;

    public NetworkViewID(int id)
    {
        this.id = id;
    }

    public bool Equals(NetworkViewID other)
    {
        return id == other.id;
    }

    public override bool Equals(object obj)
    {
        return obj is NetworkViewID other && Equals(other);
    }

    public override int GetHashCode()
    {
        return id;
    }

    public override string ToString()
    {
        return id.ToString();
    }

    public static bool operator ==(NetworkViewID left, NetworkViewID right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NetworkViewID left, NetworkViewID right)
    {
        return !left.Equals(right);
    }
}

[Serializable]
public struct NetworkPlayer : IEquatable<NetworkPlayer>
{
    private string id;

    public NetworkPlayer(string id)
    {
        this.id = id;
    }

    public string ipAddress
    {
        get { return string.Empty; }
    }

    public int port
    {
        get { return 0; }
    }

    public bool Equals(NetworkPlayer other)
    {
        return id == other.id;
    }

    public override bool Equals(object obj)
    {
        return obj is NetworkPlayer other && Equals(other);
    }

    public override int GetHashCode()
    {
        return id == null ? 0 : id.GetHashCode();
    }

    public override string ToString()
    {
        return id ?? string.Empty;
    }

    public static bool operator ==(NetworkPlayer left, NetworkPlayer right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NetworkPlayer left, NetworkPlayer right)
    {
        return !left.Equals(right);
    }
}

public sealed class NetworkView : MonoBehaviour
{
    [SerializeField]
    private NetworkViewID _viewID;

    public NetworkViewID viewID
    {
        get { return _viewID; }
        set { _viewID = value; }
    }

    public bool isMine
    {
        get { return true; }
    }

    public NetworkPlayer owner
    {
        get { return default(NetworkPlayer); }
    }

    public NetworkStateSynchronization stateSynchronization { get; set; }

    public void RPC(string name, RPCMode mode, params object[] args)
    {
    }

    public void RPC(string name, NetworkPlayer target, params object[] args)
    {
    }
}

public static class Network
{
    public static bool isServer
    {
        get { return false; }
    }

    public static bool isClient
    {
        get { return false; }
    }

    public static bool isMessageQueueRunning
    {
        get { return false; }
        set { }
    }

    public static bool useNat { get; set; }

    public static NetworkPlayer[] connections
    {
        get { return new NetworkPlayer[0]; }
    }

    public static double time
    {
        get { return Time.timeAsDouble; }
    }

    public static NetworkPlayer player
    {
        get { return default(NetworkPlayer); }
    }

    public static bool HavePublicAddress()
    {
        return false;
    }

    public static void InitializeServer(int connections, int listenPort, bool useNat)
    {
    }

    public static void Disconnect()
    {
    }

    public static void Disconnect(int timeout)
    {
    }

    public static NetworkConnectionError Connect(string IP, int remotePort)
    {
        return NetworkConnectionError.ConnectionFailed;
    }

    public static void CloseConnection(NetworkPlayer target, bool sendDisconnectionNotification)
    {
    }

    public static void RemoveRPCs(NetworkPlayer player)
    {
    }

    public static void RemoveRPCs(NetworkViewID viewID)
    {
    }

    public static UnityEngine.Object Instantiate(UnityEngine.Object prefab, Vector3 position, Quaternion rotation, int group)
    {
        return UnityEngine.Object.Instantiate(prefab, position, rotation);
    }

    public static void Destroy(UnityEngine.Object obj)
    {
        if (obj != null)
        {
            UnityEngine.Object.Destroy(obj);
        }
    }

    public static void DestroyPlayerObjects(NetworkPlayer player)
    {
    }
}

public sealed class BitStream
{
    public bool isWriting
    {
        get { return false; }
    }

    public bool isReading
    {
        get { return !isWriting; }
    }

    public void Serialize(ref Vector3 value)
    {
    }

    public void Serialize(ref Quaternion value)
    {
    }

    public void Serialize(ref bool value)
    {
    }

    public void Serialize(ref float value)
    {
    }

    public void Serialize(ref int value)
    {
    }

    public void Serialize(ref string value)
    {
    }
}

public struct NetworkMessageInfo
{
    public NetworkPlayer sender
    {
        get { return default(NetworkPlayer); }
    }

    public double timestamp
    {
        get { return Network.time; }
    }

    public NetworkView networkView
    {
        get { return null; }
    }
}
