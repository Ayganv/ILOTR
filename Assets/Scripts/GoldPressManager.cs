using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPressManager : MonoBehaviour
{
    public int generationAmount = 5;
    private int goldPressCost = 100;
    public Text goldPress;
    private float goldPressGeneration = 1f;
    private float elapsedTime;
    public int goldPressAmount {
        get => PlayerPrefs.GetInt("Gold Press", 0);
        set
        {
            PlayerPrefs.SetInt("Gold Press", value);
            UpdateGoldPressAmount();
        }
    }

    void UpdateGoldPressAmount()
    {
        this.goldPress.text = this.goldPressAmount.ToString("0 Gold Press");
    }

    void Start()
    {
        UpdateGoldPressAmount();
    }

    void Update()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.goldPressGeneration)
        {
            ProduceGold();
            this.elapsedTime -= this.goldPressGeneration;
        }
    }

    void ProduceGold()
    {
        var gold = FindObjectOfType<GoldManager>();
        gold.GoldAmount += this.generationAmount * this.goldPressAmount;
    }
    
    public void BuyGoldPress()
    {
        var gold = FindObjectOfType<GoldManager>();
        if (gold.GoldAmount >= this.goldPressCost)
        {
            gold.GoldAmount -= this.goldPressCost;
            this.goldPressAmount +=1;
        }
    }

    /*
    public void GoldGenerationPerSecond()
    {
        if (goldPressAmount > 0)
        {
            this.GoldAmount += this.goldPressAmount *(Mathf.RoundToInt(Time.deltaTime * this.goldPressGeneration));
            UpdateGoldAmountLabel();
        }
    }
    */
}
