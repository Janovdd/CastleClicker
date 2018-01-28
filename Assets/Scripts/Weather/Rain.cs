using UnityEngine;

public class Rain : MonoBehaviour {
    public bool isOn;
    private ParticleSystem rain;
    // Use this for initialization
    void Start()
    {
        isOn = false;
        rain = GetComponent<ParticleSystem>();
        rain.Stop();
    }

    // Update is called once per frame
    void Update () {
        if (isOn)
        {
            rain.Play();
        }
        else
        {
            rain.Stop();
        }
	}
}
