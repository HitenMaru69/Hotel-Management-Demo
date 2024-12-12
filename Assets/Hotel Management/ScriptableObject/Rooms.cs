using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rooms", menuName = "RoomsList/Rooms")]
public class Rooms : ScriptableObject
{
    public List<RoomData> roomDatas;
}

[System.Serializable]
public class RoomData
{
    public String LevelName;
    public int RoomUnlocked;
}
