using UnityEngine;
using System.Collections;

public class Tovectory : MonoBehaviour {

    public Collider2D collider;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        Application.LoadLevel(3);
    }
}
