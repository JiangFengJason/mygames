using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour {
    private float rotationSpeed;
    public GameObject target;
    private float distance;
	// Use this for initialization
	void Start () {
        rotationSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= 0.2f && transform.localEulerAngles.y >= 0f && transform.localEulerAngles.y <= 120.0f)
        {
            transform.Rotate(new Vector3(0, rotationSpeed, 0));
        }
	}
}
