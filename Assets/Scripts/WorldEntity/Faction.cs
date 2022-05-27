using UnityEngine;

[CreateAssetMenu(menuName = "Faction")]
public class Faction : ScriptableObject
{
    public FactionType value;
    public bool isBefriendable;
    public ScriptableVector3 leaderPosition;
}

public enum FactionType
{
    Neutral,
    Player,
    Enemy,
}