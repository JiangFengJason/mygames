using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class showdetail : MonoBehaviour {
    public GameObject detail;
    public GameObject target;
    public SteamVR_Controller.Device device;
    private bool triggerpress;
    private float distance;
	// Use this for initialization
	void Start () {
        device = SteamVR_Controller.Input((int)GetComponent<SteamVR_TrackedObject>().index);
	}
	
	// Update is called once per frame
	void Update () {
        triggerpress = device.GetPress(SteamVR_Controller.ButtonMask.Trigger);
        distance= Vector3.Distance(target.transform.position, transform.position);
        if (distance<=0.15f&&triggerpress)
        {
            detail.SetActive(true);
        }
        else
        {
            detail.SetActive(false);
        }
	}
}
