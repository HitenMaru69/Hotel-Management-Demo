using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public event EventHandler UpdateScore;
    public Rooms rooms;

    public void CallUpdateScoreEvent()
    {
        UpdateScore?.Invoke(this, EventArgs.Empty);
    }
}
