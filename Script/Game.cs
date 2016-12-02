using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
    public void OnStartGame(int sceneToLoad)
    {
        Application.LoadLevel(sceneToLoad);
    }
	// Update is called once per frame
	void Update () {
	
	}
    
}
