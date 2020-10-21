using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldProductionManager : MonoBehaviour
{
    public GoldProductionUnit goldProductionUnit;
    public Text goldPress;
    public Text purchaseButtonLabel;
    private float elapsedTime;
    
    public void SetupUnit(GoldProductionUnit goldProductionUnit) {
        this.goldProductionUnit = goldProductionUnit;
        this.gameObject.name = goldProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase {goldProductionUnit.name}";
    }

    public int goldPressAmount {
        get => PlayerPrefs.GetInt(this.goldProductionUnit.name, 0);
        set
        {
            PlayerPrefs.SetInt(this.goldProductionUnit.name, value);
            UpdateGoldPressAmount();
        }
    }

    void Start()
    {
        UpdateGoldPressAmount();
    }

    void Update()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.goldProductionUnit.goldPressGeneration)
        {
            ProduceGold();
            this.elapsedTime -= this.goldProductionUnit.goldPressGeneration;
        }
    }
    void UpdateGoldPressAmount()
    {
        this.goldPress.text = this.goldPressAmount.ToString("0 Gold Press");
    }

    void ProduceGold()
    {
        var gold = FindObjectOfType<GoldManager>();
        gold.GoldAmount += this.goldProductionUnit.generationAmount * this.goldPressAmount;
    }
    
    public void BuyGoldPress()
    {
        var gold = FindObjectOfType<GoldManager>();
        if (gold.GoldAmount >= this.goldProductionUnit.goldPressCost)
        {
            gold.GoldAmount -= this.goldProductionUnit.goldPressCost;
            this.goldPressAmount +=1;
        }
    }
}
