using System;
using System.Collections.Generic;
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

    private List<GameObject> cloud;
    private List<GameObject> rain;
    private List<GameObject> thunder;

    private bool rainIsOn;
    private bool thunderIsOn;

    // Use this for initialization
    void Start()
    {
        cloud = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cloud"));
        rain = new List<GameObject>(GameObject.FindGameObjectsWithTag("Rain"));
        thunder = new List<GameObject>(GameObject.FindGameObjectsWithTag("Thunder"));

        rainIsOn = false;
        thunderIsOn = false;
        random = new System.Random();

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
        if (!thunderIsOn)
        {
            thunderIsOn = true;
            for(int i = 0;i<=thunder.Capacity; i++)
            {
                var component = thunder[i].GetComponent<Thunder>();
                component.isOn = true;
            }
        }
    }

    private void RainOn()
    {
        if (!rainIsOn)
        {
            rainIsOn = true;
            for(int i=0;i<=cloud.Capacity; i++)
            {
                var component = cloud[i].GetComponent<Cloud>();
                component.isOn = true;
            }
            new WaitForSeconds(3);
            for (int i = 0; i <= rain.Capacity; i++)
            {
                var component = rain[i].GetComponent<Rain>();
                component.isOn = true;
            }
        }
    }
    private void ThunderOff()
    {
        if (thunderIsOn)
        {
            thunderIsOn = false;
            for (int i = 0; i <= thunder.Capacity; i++)
            {
                var component = thunder[i].GetComponent<Thunder>();
                component.isOn = false;
            }
        }
    }
    private void RainOff()
    {
        if (rainIsOn)
        {
            rainIsOn = false;
            for (int i = 0; i <= rain.Capacity; i++)
            {
                var component = rain[i].GetComponent<Rain>();
                component.isOn = true;
            }
            new WaitForSeconds(3);
            for (int i = 0; i <= cloud.Capacity; i++)
            {
                var component = cloud[i].GetComponent<Cloud>();
                component.isOn = true;
            }
        }
    }
}
