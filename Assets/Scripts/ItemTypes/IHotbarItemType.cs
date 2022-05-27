using UnityEngine;

public interface IHotbarItemType
{
    public void Use();
    public void UseAlternative();
    public Sprite GetIcon();
}