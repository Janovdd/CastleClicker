using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropUpgradeManager : MonoBehaviour
{
    public Text UpgradeDescription;
    public Text UpgradeTitle;
    public Text UpgradeCost;
    public Text UpgradeAmount;
    public Text ButtonText;
    public CropManager cropManager;
    public GoldManager goldManager;
    public DiamondManager diamondManager;
    public VaultManager vaultManager;
    private NumberConverter NC;
    public float cost;
    public float cropBonus;
    private float baseCost;
    public int amount;
    public int maxAmount;
    public string upgradeName;
    public bool needsDiamonds;
    public string upgradeDescription;
    public Sprite greenButton;
    public Sprite grayButton;
   
    

    // Use this for initialization
    void Start()
    {
        baseCost = cost;
        NC = new NumberConverter();
    }

    // Update is called once per frame
    void Update()
    {
        UpgradeDescription.text = upgradeDescription;
        UpgradeTitle.text = upgradeName;
        UpgradeAmount.text = amount + " / " + maxAmount;
        ButtonText.text =  "Upgrade";

        if (needsDiamonds == true)
        {
            UpgradeCost.text = NC.GetNumberIntoString(cost, false) + " Diamonds";

            if (diamondManager.diamonds >= cost && amount < maxAmount)
            {
                GetComponent<Image>().sprite = greenButton;
            }
            else
            {
                GetComponent<Image>().sprite = grayButton;
            }
        }
        else
        {
            UpgradeCost.text = NC.GetNumberIntoString(cost, false) + " Gold";

            if (goldManager.gold >= cost && amount < maxAmount)
            {
                GetComponent<Image>().sprite = greenButton;
            }
            else
            {
                GetComponent<Image>().sprite = grayButton;
            }
        }

        if (amount >= maxAmount)
        {
            cost = 0;
            ButtonText.text = "Sold out";
        }      
    }

    public void PurchasedUpgrade()
    {
        if (needsDiamonds == true)
        {
            if(diamondManager.diamonds >= cost && amount < maxAmount)
            {
                diamondManager.diamonds -= cost;
                amount += 1;
                cropManager.cropValue *= cropBonus;
                vaultManager.diamonds +=1;
                cost = Mathf.Round(baseCost * Mathf.Pow(1.2f, amount));
            }
        }
        else
        {
            if (goldManager.gold >= cost && amount < maxAmount)
            {
                goldManager.gold -= cost;
                amount += 1;
                cropManager.cropValue *= cropBonus;
                vaultManager.diamonds += 1;
                cost = Mathf.Round(baseCost * Mathf.Pow(1.2f, amount));
            }
        }
       
    }
}

