//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Lobbies.Http;



namespace Unity.Services.Lobbies.Models
{
    /// <summary>
    /// Data about an individual lobby.
    /// <param name="id">id param</param>
    /// <param name="lobbyCode">A short code that be used to join a lobby. This is only visible to lobby members. Typically this is displayed to the user so they can share it with other players out of game. Users with the code can join the lobby even when it is private.</param>
    /// <param name="upid">The Unity project ID of the game.</param>
    /// <param name="environmentId">The ID of the environment this lobby exists in</param>
    /// <param name="name">The name of the lobby. Typically this shown in game UI to represent the lobby.</param>
    /// <param name="maxPlayers">The maximum number of players that can be members of the lobby.</param>
    /// <param name="availableSlots">The number of remaining open slots for players before the lobby becomes full.</param>
    /// <param name="isPrivate">Whether the lobby is private or not. Private lobbies do not appear in query results.</param>
    /// <param name="isLocked">Whether the lobby is locked or not. Locked lobbies cannot be joined.</param>
    /// <param name="players">The members of the lobby.</param>
    /// <param name="data">Properties of the lobby set by the host.</param>
    /// <param name="hostId">The ID of the player that is the lobby host.</param>
    /// <param name="created">When the lobby was created. The timestamp is in UTC and conforms to ISO 8601.</param>
    /// <param name="lastUpdated">When the lobby was last updated. The timestamp is in UTC and conforms to ISO 8601.</param>
    /// </summary>

    [Preserve]
    [DataContract(Name = "Lobby")]
    public class Lobby
    {
        /// <summary>
        /// Data about an individual lobby.
        /// </summary>
        /// <param name="id">id param</param>
        /// <param name="lobbyCode">A short code that be used to join a lobby. This is only visible to lobby members. Typically this is displayed to the user so they can share it with other players out of game. Users with the code can join the lobby even when it is private.</param>
        /// <param name="upid">The Unity project ID of the game.</param>
        /// <param name="environmentId">The ID of the environment this lobby exists in</param>
        /// <param name="name">The name of the lobby. Typically this shown in game UI to represent the lobby.</param>
        /// <param name="maxPlayers">The maximum number of players that can be members of the lobby.</param>
        /// <param name="availableSlots">The number of remaining open slots for players before the lobby becomes full.</param>
        /// <param name="isPrivate">Whether the lobby is private or not. Private lobbies do not appear in query results.</param>
        /// <param name="isLocked">Whether the lobby is locked or not. Locked lobbies cannot be joined.</param>
        /// <param name="players">The members of the lobby.</param>
        /// <param name="data">Properties of the lobby set by the host.</param>
        /// <param name="hostId">The ID of the player that is the lobby host.</param>
        /// <param name="created">When the lobby was created. The timestamp is in UTC and conforms to ISO 8601.</param>
        /// <param name="lastUpdated">When the lobby was last updated. The timestamp is in UTC and conforms to ISO 8601.</param>
        [Preserve]
        public Lobby(string id = default, string lobbyCode = default, string upid = default, string environmentId = default, string name = default, int maxPlayers = default, int availableSlots = default, bool isPrivate = default, bool isLocked = default, List<Player> players = default, Dictionary<string, DataObject> data = default, string hostId = default, DateTime created = default, DateTime lastUpdated = default)
        {
            Id = id;
            LobbyCode = lobbyCode;
            Upid = upid;
            EnvironmentId = environmentId;
            Name = name;
            MaxPlayers = maxPlayers;
            AvailableSlots = availableSlots;
            IsPrivate = isPrivate;
            IsLocked = isLocked;
            Players = players;
            Data = data;
            HostId = hostId;
            Created = created;
            LastUpdated = lastUpdated;
        }

        /// <summary>
        /// 
        /// </summary>
        [Preserve]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id{ get; }
        /// <summary>
        /// A short code that be used to join a lobby. This is only visible to lobby members. Typically this is displayed to the user so they can share it with other players out of game. Users with the code can join the lobby even when it is private.
        /// </summary>
        [Preserve]
        [DataMember(Name = "lobbyCode", EmitDefaultValue = false)]
        public string LobbyCode{ get; }
        /// <summary>
        /// The Unity project ID of the game.
        /// </summary>
        [Preserve]
        [DataMember(Name = "upid", EmitDefaultValue = false)]
        public string Upid{ get; }
        /// <summary>
        /// The ID of the environment this lobby exists in
        /// </summary>
        [Preserve]
        [DataMember(Name = "environmentId", EmitDefaultValue = false)]
        public string EnvironmentId{ get; }
        /// <summary>
        /// The name of the lobby. Typically this shown in game UI to represent the lobby.
        /// </summary>
        [Preserve]
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name{ get; }
        /// <summary>
        /// The maximum number of players that can be members of the lobby.
        /// </summary>
        [Preserve]
        [DataMember(Name = "maxPlayers", EmitDefaultValue = false)]
        public int MaxPlayers{ get; }
        /// <summary>
        /// The number of remaining open slots for players before the lobby becomes full.
        /// </summary>
        [Preserve]
        [DataMember(Name = "availableSlots", EmitDefaultValue = false)]
        public int AvailableSlots{ get; }
        /// <summary>
        /// Whether the lobby is private or not. Private lobbies do not appear in query results.
        /// </summary>
        [Preserve]
        [DataMember(Name = "isPrivate", EmitDefaultValue = true)]
        public bool IsPrivate{ get; }
        /// <summary>
        /// Whether the lobby is locked or not. Locked lobbies cannot be joined.
        /// </summary>
        [Preserve]
        [DataMember(Name = "isLocked", EmitDefaultValue = true)]
        public bool IsLocked{ get; }
        /// <summary>
        /// The members of the lobby.
        /// </summary>
        [Preserve]
        [DataMember(Name = "players", EmitDefaultValue = false)]
        public List<Player> Players{ get; }
        /// <summary>
        /// Properties of the lobby set by the host.
        /// </summary>
        [Preserve]
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public Dictionary<string, DataObject> Data{ get; }
        /// <summary>
        /// The ID of the player that is the lobby host.
        /// </summary>
        [Preserve]
        [DataMember(Name = "hostId", EmitDefaultValue = false)]
        public string HostId{ get; }
        /// <summary>
        /// When the lobby was created. The timestamp is in UTC and conforms to ISO 8601.
        /// </summary>
        [Preserve]
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public DateTime Created{ get; }
        /// <summary>
        /// When the lobby was last updated. The timestamp is in UTC and conforms to ISO 8601.
        /// </summary>
        [Preserve]
        [DataMember(Name = "lastUpdated", EmitDefaultValue = false)]
        public DateTime LastUpdated{ get; }
    
    }
}

