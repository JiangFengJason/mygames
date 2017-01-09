using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class showdetail : MonoBehaviour {
    public GameObject detail;
    public GameObject target;
    public AudioClip record,background;
    AudioSource recordSound,backgroundSound;
    public SteamVR_Controller.Device device;
    private bool triggerpress;
    private bool play;
    private float distance;
    private float timer;
	// Use this for initialization
	void Start () {
        device = SteamVR_Controller.Input((int)GetComponent<SteamVR_TrackedObject>().index);
        recordSound = gameObject.AddComponent<AudioSource>();
        recordSound.clip = record;
        play = true;
        timer = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        triggerpress = device.GetPress(SteamVR_Controller.ButtonMask.Trigger);
        distance= Vector3.Distance(target.transform.position, transform.position);
        if (distance<=0.15f&&triggerpress)
        {
            timer -= Time.deltaTime;
            detail.SetActive(true);
            if (timer <= 0&&play)
            {
                recordSound.Play();
                play = false;
                timer = 3f;
            }
        }
        else
        {
            recordSound.Stop();
            detail.SetActive(false);
            timer = 3f;
            play = true;
        }
	}
}
