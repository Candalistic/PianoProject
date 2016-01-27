using UnityEngine;
using Leap;
using System.Collections;

public class PlayPiano : MonoBehaviour {
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = new Controller();
        invisibleHand();
    }

    public void invisibleHand()
    {
        Frame frame = controller.Frame();
        FingerList fingers = frame.Fingers;
        /*foreach(Finger finger in fingers)
        {
            finger.
        }*/
    }
	


	// Update is called once per frame
	void Update () {
	    
	}
}
