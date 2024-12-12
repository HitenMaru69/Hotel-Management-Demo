using UnityEngine;

public class Room : MonoBehaviour
{
    public RoomType type;

    public GameObject CleanText;

    public GameObject gameObject1;
    public GameObject gameObject2;

    private void Start()
    {
        type = RoomType.Clean;

        if (type == RoomType.Clean)
        {
            CleanText.SetActive(true);
        }

        gameObject1.SetActive(false);
        gameObject2.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(NameTag.Player))
        {
            
            StartTimeToClean();
        }

        if(other.gameObject.CompareTag(NameTag.NPC))
        {
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.CompareTag(NameTag.NPC))
        {
            
            type = RoomType.Clean;
            CleanText.SetActive(true);
        }
    }

    void StartTimeToClean()
    {
      ;
        float total = 5;

        while (total > 0)
        {
         
            if (total >= 0)
            {
                total -= Time.deltaTime;

            }
        }

   

        type = RoomType.Available;
        CleanText.SetActive(false);
    }
}
