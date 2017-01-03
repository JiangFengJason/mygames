using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour {
    public Transform Head;
    public float rotationSpeed;
    private Vector3 n;
    private GameObject obj;
    public float distance;
	// Use this for initialization
	void Start () {
        rotationSpeed = 0.5f;
        obj = GetComponent<SteamVR_ControllerManager>().right;
	}
	
	// Update is called once per frame
	void Update () {
        n = obj.transform.position;
        distance = Vector3.Distance(n, transform.position);
        if (Vector3.Distance(n, transform.position) <= 10f)
        {
            if (transform.localEulerAngles.y >= -91f && transform.localEulerAngles.y <= 112.0f)
                transform.Rotate(new Vector3(0, rotationSpeed, 0));
        }
        else if (transform.localEulerAngles.y <= 111.0f && transform.localEulerAngles.y >= -90.00f)
            transform.Rotate(new Vector3(0, -rotationSpeed, 0));
	}
}
