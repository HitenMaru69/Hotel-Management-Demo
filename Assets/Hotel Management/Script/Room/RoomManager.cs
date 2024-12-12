using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum RoomType
{
    Available,
    Taken,
    Clean
}


public class RoomManager : MonoBehaviour
{
    [SerializeField] UIManager uIManager;

    public static RoomManager instance;
    public List<Room> rooms = new();
    public Rooms roomData;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        for (int i = 0; i < rooms.Count; i++)
        {
            rooms[roomData.roomDatas[0].RoomUnlocked].gameObject.SetActive(true);  
        }
   

    }


    public void UnlockNewRoom(int a)
    {
        if (PlayerPrefs.GetInt(NameTag.TotalMoney) >= a)
        {
            int c = PlayerPrefs.GetInt(NameTag.TotalMoney) - a;

            PlayerPrefs.SetInt(NameTag.TotalMoney, c);

            uIManager.totalMoney_Txt.text = c.ToString();

            roomData.roomDatas[0].RoomUnlocked += 1;

            for (int i = 0; i < rooms.Count; i++)
            {
                rooms[roomData.roomDatas[0].RoomUnlocked].gameObject.SetActive(true);
            }
        }
    }


}
