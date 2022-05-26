using UnityEngine;

[CreateAssetMenu(menuName = "Faction")]
public class Faction : ScriptableObject
{
    public FactionType value;
}

public enum FactionType
{
    Neutral,
    Player,
    Enemy,
}