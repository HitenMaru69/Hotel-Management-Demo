using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    public TextMeshProUGUI totalMoney_Txt;

    public GameObject attendBu;
    public int incressMoneyAmount = 20;


    private int money = 0;

    private void OnEnable()
    {
        gameManager.UpdateScore += OnUpdateMoney;
    }

    private void Awake()
    {
        attendBu.SetActive(false);
      
    }

    private void Start()
    {
         money = PlayerPrefs.GetInt(NameTag.TotalMoney, 0);
         totalMoney_Txt.text = money.ToString();
    }

    private void OnDisable()
    {
        gameManager.UpdateScore -= OnUpdateMoney;
    }

    private void OnUpdateMoney(object sender, System.EventArgs e)
    {
        money += incressMoneyAmount;
        PlayerPrefs.SetInt(NameTag.TotalMoney, money);
        totalMoney_Txt.text = money.ToString();
    }

    

}
