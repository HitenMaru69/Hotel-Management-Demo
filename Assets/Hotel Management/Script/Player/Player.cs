using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(NameTag.Table))
        {
            if(NPCController.Instance.customerQueue.Count >0 ) {
                uiManager.attendBu.SetActive(true);
            }
        }

        if(other.gameObject.CompareTag(NameTag.Money))
        {
            gameManager.CallUpdateScoreEvent();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        uiManager.attendBu.SetActive(false);
    }

}
