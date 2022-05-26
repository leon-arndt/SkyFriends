using UnityEngine;

public class Faction : MonoBehaviour
{
    public FactionType value;
}

public enum FactionType
{
    Neutral,
    Player,
    Enemy,
}