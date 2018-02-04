using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycleDL : MonoBehaviour {
    private PhaseTimer dayNightTimer;
    private int currentPhase;
    private Light backGroundLight;
    public Color colorPhase0 = Color.white;
    public Color colorPhase2 = Color.black;
    private float timeElapsed = 0;
    // Use this for initialization
    void Start () {
        dayNightTimer = new PhaseTimer();

        backGroundLight = GetComponent<Light>();
        backGroundLight.color = Color.white;
        dayNightTimer.Start();
        currentPhase = dayNightTimer.phase;
    }
	
	// Update is called once per frame
	void Update () {
        if (currentPhase != dayNightTimer.phase)
        {
            currentPhase = dayNightTimer.phase;
            updateColors(currentPhase);
        }
        if ((currentPhase == 1 || currentPhase == 3) && timeElapsed < 1)
        {
            if (currentPhase == 1)
            {
                backGroundLight.color = Color.Lerp(colorPhase0, colorPhase2, timeElapsed);
                timeElapsed += Time.deltaTime / dayNightTimer.phase2;
            }
            if (currentPhase == 3)
            {
                backGroundLight.color = Color.Lerp(colorPhase2, colorPhase0, timeElapsed);
                timeElapsed += Time.deltaTime / dayNightTimer.phase4;
            }
        }
    }

    private void updateColors(int phase)
    {
        switch (phase)
        {
            case 0:
                backGroundLight.color = colorPhase0;
                break;
            case 1:
                timeElapsed = 0;
                break;
            case 2:
                backGroundLight.color = colorPhase2;
                break;
            case 3:
                timeElapsed = 0;
                break;
            default:
                break;
        }
    }
}
