using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "ScriptableObjects/SpawnPlayerInfoScriptableObject", order = 1)]
public class PlayerInfo : ScriptableObject
{
    public float speed;
}
