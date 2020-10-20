using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int goldAmount;

    public Text goldAmountText;

    void Start()
    {
        this.goldAmount = PlayerPrefs.GetInt("Gold", 1);
    }
    
    void OnDestroy() {
        PlayerPrefs.SetInt("Gold", this.goldAmount);
    }

    void Update()
    {
        this.goldAmountText.text = this.goldAmount.ToString("0 Gold");
        if (Input.GetMouseButtonDown(0)) {
            ProduceGold();
        }
    }
    
    public void ProduceGold() {
        this.goldAmount += 5; // this.goldAmount = this.goldAmount + 5;
    }
}
