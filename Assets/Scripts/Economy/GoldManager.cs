using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour {

    public UnityEngine.UI.Text goldDisplay;
    public UnityEngine.UI.Text OverlayGoldDisplay;
    public float gold = 0;
    public float gps;
    public UnityEngine.UI.Text gpsDisplay;
    public UnityEngine.UI.Text OverlayGPSDisplay;
    public CropManager cropManager;
    public FarmerManager farmerManager;
    public ToolsManager toolsManager;
    private NumberConverter NC;

    void Start()
    {
        StartCoroutine(AutoTick());
        NC = new NumberConverter();
    }

    // Update is called once per frame
    void Update () {
        goldDisplay.text = NC.GetNumberIntoString(gold ,false) + " Gold";
        gpsDisplay.text = NC.GetNumberIntoString(GetGPS(), false) + " Gold / Sec";
        OverlayGoldDisplay.text = NC.GetNumberIntoString(gold, false) + " Gold";
        OverlayGPSDisplay.text = NC.GetNumberIntoString(GetGPS(), false) + " Gold / Sec";
    }

    public float GetGPS()
    {
        gps = cropManager.cropValue * farmerManager.farmers * (toolsManager.CPS / 60);
        return gps;
    }

    public void AutoGPS()
    {
        gold += GetGPS() / 10;
    }

    IEnumerator AutoTick()
    {
        while (true)
        {
            AutoGPS();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
