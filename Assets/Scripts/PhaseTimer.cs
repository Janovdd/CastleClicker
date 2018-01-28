using System.Collections.Generic;
using System.Timers;

public class PhaseTimer{
    private Timer timeToUpdate;
    private List<int> phases = new List<int>();
    public int phase;
	// Use this for initialization
	public void Start () {
        if(phases.Count == 0)
        {
            return;
        }
        phase = 0;
        //setting timer and timer eventhandler
        timeToUpdate = new Timer
        {
            Interval = phases[phase]
        };
        timeToUpdate.Elapsed += UpdateCycle;
        timeToUpdate.AutoReset = true;
        timeToUpdate.Enabled = true;
	}
    // Update is called when timeToUpdate has reached Elapsed event
    private void UpdateCycle (object sender, ElapsedEventArgs e) {
        timeToUpdate.Enabled = false;
        phase++;
        if (phase >= phases.Count)
            phase = 0;
        timeToUpdate.Interval = phases[phase];
        timeToUpdate.Enabled = true;
    }
    public void addPhase(int intervalTime)
    {
        phases.Add(intervalTime * 1000);
    }
    public void removePhase(int phase)
    {
        phases.Remove(phase);
    }
    
}
