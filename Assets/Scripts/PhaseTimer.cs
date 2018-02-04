using System.Collections.Generic;
using System.Timers;

public class PhaseTimer{
    private Timer timeToUpdate;
    private List<int> phases = new List<int>();
    public int phase;

    public int phase1 = 20;
    public int phase2 = 5;
    public int phase3 = 20;
    public int phase4 = 5;

	// Use this for initialization
	public void Start () {
        phase = 0;
        addPhase(phase1);
        addPhase(phase2);
        addPhase(phase3);
        addPhase(phase4);
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
