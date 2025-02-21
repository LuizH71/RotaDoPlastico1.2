using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listerners =
        new List<GameEventListener>();

    public void Raise()
    {
        for(int i = listerners.Count -1; i>=0; i--)
        {
            listerners[i].OnEventRaised();
        }
    }

    public void RegisterListeners(GameEventListener listener)
    {
        listerners.Add(listener);
    }
    public void UnregisterListeners(GameEventListener listener)
    {
        listerners.Remove(listener);
    }
}
