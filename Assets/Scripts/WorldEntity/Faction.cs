using UnityEngine;

[CreateAssetMenu(menuName = "Faction")]
public class Faction : ScriptableObject
{
    public FactionType value;
    public bool isBefriendable;
    [Range(0.01f, 1f)]
    public float befriendChance;
    public ScriptableVector3 leaderPosition;
}

public enum FactionType
{
    Neutral,
    Player,
    Enemy,
}