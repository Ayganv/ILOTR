using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int goldAmount;

    public Text goldAmountText;

    void Update()
    {
        this.goldAmountText.text = this.goldAmount.ToString("0 Gold");
    }
    
    public void ProduceGold() {
        this.goldAmount += 5; // this.goldAmount = this.goldAmount + 5;
    }
}
