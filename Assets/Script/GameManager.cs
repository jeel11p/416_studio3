using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
   public int currentCoin;
   //public Text coinText;
   [SerializeField] private TextMeshProUGUI coinText;
    
    public void AddCoin(int coinToAdd)
    {
        currentCoin += coinToAdd;
        coinText.text = "Coin: " + currentCoin;
    }
}
