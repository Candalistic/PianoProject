using UnityEngine;
using Leap;
using System.Collections;

public class PlayPiano : MonoBehaviour {
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = new Controller();
        Frame frame = controller.Frame();
        FingerList fingers = frame.Fingers;

    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
