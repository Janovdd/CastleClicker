using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerManager : MonoBehaviour
{

    public UnityEngine.UI.Text fpmDisplay;
    public UnityEngine.UI.Text farmerDisplay;
    public UnityEngine.UI.Text OverlayFarmerDisplay;
    public float farmers = 0;
    public GoldManager gold;
    public FarmerUpgradeManager[] upgrades;
    private NumberConverter NC;


    void Start()
    {
        StartCoroutine(AutoTick());
        NC = new NumberConverter();
    }

    // Update is called once per frame
    void Update()
    {
        farmerDisplay.text = NC.GetNumberIntoString(farmers, false) + " Farmers";
        OverlayFarmerDisplay.text = NC.GetNumberIntoString(farmers, false) + " Farmers";
        fpmDisplay.text = NC.GetNumberIntoString(GetFPS(), false) + " Farmers / Minute";
    }

    public float GetFPS()
    {
        float tick = 0;
        foreach (FarmerUpgradeManager upgrade in upgrades)
        {
            tick += upgrade.amount * upgrade.fps;
        }
        return tick;
    }

    public void AutoFPS()
    {
        farmers += GetFPS() / 600;
    }

    IEnumerator AutoTick()
    {
        while (true)
        {
            AutoFPS();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
