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
        transform.Translate(Vector3.left * 0.05f);
        if (transform.position.x < -3)
        {
                Destroy(gameObject);
        }
    }
    }
}
