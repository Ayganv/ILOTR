using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int goldAmount;

    public Text goldAmountText;
    public int goldAmountPerClick = 5;

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
        this.goldAmount += goldAmountPerClick; // this.goldAmount = this.goldAmount + 5;
    }
}
