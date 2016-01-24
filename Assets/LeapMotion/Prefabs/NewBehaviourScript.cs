using UnityEngine;
using Leap;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    Controller controller;
    GameObject[] keys;
    // Use this for initialization
    void Start() {
        controller = new Controller();
        controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
        controller.Config.SetFloat("Gesture.KeyTap.MinDistance", 1.0f);
        controller.Config.SetFloat("Gesture.KeyTap.MinDownVelocity", 10.0f);
        keys = new GameObject[12];
        keys[0] = GameObject.Find("C");
        keys[1] = GameObject.Find("C#");
        keys[2] = GameObject.Find("D");
        keys[3] = GameObject.Find("D#");
        keys[4] = GameObject.Find("E");
        keys[5] = GameObject.Find("F");
        keys[6] = GameObject.Find("F#");
        keys[7] = GameObject.Find("G");
        keys[8] = GameObject.Find("G#");
        keys[9] = GameObject.Find("A");
        keys[10] = GameObject.Find("A#");
        keys[11] = GameObject.Find("B");
        for (int i = 0; i < keys.Length; i++) {
            Vector3 pos = keys[i].transform.position;
            print(pos.x + " " + pos.y + " " + pos.z);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Frame frame = controller.Frame();
        GestureList gestures = frame.Gestures();
        for(int i=0; i<gestures.Count; i++)
            if(gestures[i].Type == Gesture.GestureType.TYPE_KEY_TAP)
            {
                //Do some stuff
                KeyTapGesture key_tap = new KeyTapGesture(gestures[i]);
                Vector3 pos = key_tap.Position.ToUnityScaled();
                float x = pos.x;
                float y = pos.y;
                float z = pos.z;
                print("LM Coordinates: (" + key_tap.Position.x + ", " + key_tap.Position.y + ", " + key_tap.Position.z + ")");
                print("Unity coordinates: (" + x + ", " + y + ", " + z + ")");
                //Vector3 scaledPos = pos * 
            }
	}
}
