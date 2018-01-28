using System;
using System.Timers;
using UnityEngine;

public class WeatherCycle : MonoBehaviour
{
    private int phase; //0=Clear, 1=Clouds+Rain, 2=Clouds+Rain+Thunder
    private int previousPhase;

    private SpriteRenderer backGroundSprite;
    private float timeElapsed = 0;
    private Timer timeToUpdate;

    private System.Random random;

    private bool rain;
    private bool thunder;

    // Use this for initialization
    void Start()
    {
        phase = 0;
        timeToUpdate = new Timer
        {
            Interval = random.Next(2, 10) * 15000
        };
        timeToUpdate.Elapsed += UpdateCycle;
        timeToUpdate.AutoReset = true;
        timeToUpdate.Enabled = true;
    }

    // Update is called when timeToUpdate has reached Elapsed event
    void UpdateCycle(object sender, ElapsedEventArgs e)
    {
        timeToUpdate.Enabled = false;
        timeToUpdate.Interval = random.Next(2, 10) * 15000;
        int firstPhase = phase;
        while (phase == firstPhase)
            phase = random.Next(0, 2);
        timeElapsed = 0;
        timeToUpdate.Enabled = true;
    }

    private void Update()
    {
        switch (phase)
        {
            case 0:
                ThunderOff();
                RainOff();
                break;
            case 1:
                ThunderOff();
                RainOn();
                break;
            case 2:
                ThunderOn();
                RainOn();
                break;
            default:
                break;
        }
    }

    private void ThunderOn()
    {
        if (!thunder)
        {
            thunder = true;
            //code for enabling random thunder animation
        }
    }

    private void RainOn()
    {
        if (!rain)
        {
            rain = true;
            //code for clouds moving in
            //code for enabling rain after clouds moving in
        }
    }
    private void ThunderOff()
    {
        if (thunder)
        {
            thunder = false;
            //code for disabling random thunder animation
        }
    }
    private void RainOff()
    {
        if (rain)
        {
            rain = false;
            //code for disabling rain
            //code for clouds moving away after rain stopped
        }
    }
}
