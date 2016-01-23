using UnityEngine;
using Leap;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = new Controller();
        controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
	}
	
	// Update is called once per frame
	void Update () {
        Frame frame = controller.Frame();
        GestureList gestures = frame.Gestures();
        for(int i=0; i<gestures.Count; i++)
            if(gestures[i].Type == Gesture.GestureType.TYPE_KEY_TAP)
            {
                //Do some stuff
                print(gestures[i].Type);
                KeyTapGesture key_tap = (KeyTapGesture)gestures[i];
                Vector3 pos = key_tap.Position.ToUnityScaled();
                float x = pos.x;
                float y = pos.y;
                float z = pos.z;
                print(x + " " + y + " " + z);
            }
	}
}
