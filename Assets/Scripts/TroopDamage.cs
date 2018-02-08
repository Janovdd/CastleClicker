using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopDamage : MonoBehaviour
{

    private IEnumerator coroutine;
    private int dps;
    private int st;
    public GameObject knight;

    // Use this for initialization
    void Start()
    {
        dps = knight.GetComponent<Troop>().dps;
        st = knight.GetComponent<Troop>().dps;
        StartCoroutine(waitSecond(dps, st));
    } 

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator waitSecond(int dpsi, int sut)
    {
        while (st > 0)
        {
            doDamage(dps, st);
            yield return new WaitForSeconds(1f);
        }
        Destroy(this.gameObject);
        GameObject.Find("damagePerSecond").GetComponent<DamageManager>().dps -= dps;
    }

    void doDamage(int dpsi, int sut)
    {
        GameObject.FindWithTag("enemyCastle").GetComponent<Enemy>().health -= dps;
        st = st - 1;
    }
}