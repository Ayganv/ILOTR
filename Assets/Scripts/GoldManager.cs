using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour {
    public int goldAmountPerClick = 5;
    public Text goldAmountText;
    
    //gold press only
    private int goldPressCost = 100;
    public int goldPressAmount;
    public Text goldPress;

    public int GoldAmount {
        get => PlayerPrefs.GetInt("Gold", 1);
        set {
            PlayerPrefs.SetInt("Gold", value);
            UpdateGoldAmountLabel();
        }
    }

    void UpdateGoldAmountLabel() {
        this.goldAmountText.text = this.GoldAmount.ToString("0 Gold");
    }

    void UpdateGoldPressAmount()
    {
        this.goldPressAmount +=1;
        this.goldPress.text = this.goldPressAmount.ToString("0 Gold Press");
    }

    void Start() {
        UpdateGoldAmountLabel();
    }
	
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ProduceGold();
        }
    }

    public void ProduceGold() {
        this.GoldAmount += this.goldAmountPerClick;
    }

    public void BuyGoldPress()
    {
        if (GoldAmount >= goldPressCost)
        {
            this.GoldAmount -= goldPressCost;
            UpdateGoldPressAmount();
            UpdateGoldAmountLabel();
        }
        
    }
}