using System.Collections.Generic;
using Events;
using UniRx;
using UnityEngine;

[CreateAssetMenu(menuName = "HotbarSystem")]
public class HotbarSystem : ScriptableObject
{
    private uint _activeElementIndex;
    private List<IHotbarItemType> _currentItems;

    private void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        _activeElementIndex = 0;
        _currentItems = new List<IHotbarItemType>();
    }
    
    public void SetActive(uint i)
    {
        _activeElementIndex = i;
        MessageBroker.Default.Publish(new HotbarChanged());
    }

    public uint GetActive()
    {
        return _activeElementIndex;
    }
    
    public void UseActive()
    {
        if (_activeElementIndex < _currentItems.Count)
        {
            _currentItems[(int)_activeElementIndex].Use();
        }
    }

    public void UseActiveAlternative()
    {
        if (_activeElementIndex < _currentItems.Count)
        {
            _currentItems[(int)_activeElementIndex].UseAlternative();
        }
    }
    
    public List<IHotbarItemType> GetAll()
    {
        return _currentItems;
    }

    public void Add(IHotbarItemType item)
    {
        _currentItems.Add(item);
        MessageBroker.Default.Publish(new HotbarChanged());
    }
    
    public void Remove(IHotbarItemType item)
    {
        _currentItems.Remove(item);
        MessageBroker.Default.Publish(new HotbarChanged());
    }
}
