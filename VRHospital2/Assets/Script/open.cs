using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour {
    SteamVR_Controller.Device device;
    private float rotationSpeed;
    public GameObject target;
    public GameObject center;
    private float distance;
    private bool triggerpress;
	// Use this for initialization
	void Start () {
        rotationSpeed = 0.5f;
        device = SteamVR_Controller.Input((int)GetComponent<SteamVR_TrackedObject>().index);
	}
	
	// Update is called once per frame
	void Update () {
        triggerpress = device.GetPress(SteamVR_Controller.ButtonMask.Trigger);
        distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= 0.2f&&triggerpress)
        {
            if (target.transform.localRotation.y >= -90f && target.transform.localRotation.y <= 80.0f)
            {
                center.transform.Rotate(new Vector3(0, rotationSpeed, 0));
            }
        }
	}
}
