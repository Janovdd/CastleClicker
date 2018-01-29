using UnityEngine;

public class Rain : MonoBehaviour {
    public bool isOn;
    private bool setOn;
    private ParticleSystem rain;
    // Use this for initialization
    void Start()
    {
        isOn = false;
        setOn = false;
        rain = GetComponent<ParticleSystem>();
        if(rain.isPlaying)
            rain.Stop();
    }

    // Update is called once per frame
    void Update () {
        if (isOn && !setOn)
        {
            setOn = true;
            rain.Play();
        }
        if(!isOn && setOn)
        {
            setOn = false;
            rain.Stop();
        }
	}
}
