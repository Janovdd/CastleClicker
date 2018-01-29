using System.Timers;
using UnityEngine;

public class Thunder : MonoBehaviour {
    public bool isOn;
    private System.Random random = new System.Random();
    private Timer timer;
    private Animator thunder;
	// Use this for initialization
	void Start () {
        isOn = false;
        timer = new Timer
        {
            Interval = random.Next(2, 10) * 1000
        };
        thunder = GetComponent<Animator>();
        thunder.enabled = false;
        timer.Elapsed += UpdateCycle;
        timer.AutoReset = true;
        timer.Enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        timer.Enabled = true;
	}
    void UpdateCycle(object sender, ElapsedEventArgs e)
    {
        timer.Enabled = false;
        timer.Interval = random.Next(1, 5) * 1000;
        thunder.Play("Thunder");
        timer.Enabled = true;
    }
}
