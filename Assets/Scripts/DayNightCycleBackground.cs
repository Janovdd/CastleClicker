﻿using UnityEngine;

public class DayNightCycleBackground : MonoBehaviour {
    private PhaseTimer dayNightTimer;
    private int currentPhase;
    private SpriteRenderer backGroundSprite;
    public Color colorPhase0 = Color.white;
    public Color colorPhase2 = Color.black;
    private float timeElapsed = 0;
  
	// Use this for initialization
	void Start () {
        dayNightTimer = new PhaseTimer();
        backGroundSprite = GetComponent<SpriteRenderer>();
        backGroundSprite.color = Color.white;
        dayNightTimer.Start();
        currentPhase = dayNightTimer.phase;
    }
	
	// Update is called once per frame
	void Update () {
		if(currentPhase != dayNightTimer.phase)
        {
            currentPhase = dayNightTimer.phase;
            updateColors(currentPhase);
        }
        if((currentPhase == 1 || currentPhase == 3) && timeElapsed < 1)
        {
            if (currentPhase == 1)
            {
                backGroundSprite.color = Color.Lerp(colorPhase0, colorPhase2, timeElapsed);
                timeElapsed += Time.deltaTime / dayNightTimer.phase2;
            }
            if (currentPhase == 3)
            {
                backGroundSprite.color = Color.Lerp(colorPhase2, colorPhase0, timeElapsed);
                timeElapsed += Time.deltaTime / dayNightTimer.phase4;
            }
        }
	}

    private void updateColors(int phase)
    {
        switch (phase)
        {
            case 0:
                backGroundSprite.color = colorPhase0;
                break;
            case 1:
                timeElapsed = 0;
                break;
            case 2:
                backGroundSprite.color = colorPhase2;
                break;
            case 3:
                timeElapsed = 0;
                break;
            default:
                break;
        }
    }
}
