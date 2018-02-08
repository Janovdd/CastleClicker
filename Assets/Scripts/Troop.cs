using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : Enemy
{

    public int movementSpeed;
    public int dps;
    public int survivalTime;
    private bool spawn = false;
    public GameObject troopDamage;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementSpeed * (Vector3.right * Time.deltaTime);
        if (transform.position.x > 930)
        {
            movementSpeed = 0;

            if (spawn == false) {
                Instantiate(troopDamage);
                spawn = true; 
            }

        }
    }

}