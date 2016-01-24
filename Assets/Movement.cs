using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	// Use this for initialization

	void Start () {
	}
    // Update is called once per frame
    void Update() {
        if (gameObject != null) { 
        //transform.Translate(Vector3.forward);
        transform.Translate(Vector3.back * 0.05f);
        if (transform.position.z < -0.182)
        {
                Destroy(gameObject);
        }
    }
    }
}
