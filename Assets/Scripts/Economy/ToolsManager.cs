using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{

    public UnityEngine.UI.Text cpmDisplay;
    public float CPS = 0;
    public ToolsUpgradeManager[] upgrades;
    private NumberConverter NC;

    void Start()
    {
        NC = new NumberConverter();
    }

    // Update is called once per frame
    void Update()
    {
        cpmDisplay.text = NC.GetNumberIntoString(CPS, false) + " Crops / Min";
    }
}

