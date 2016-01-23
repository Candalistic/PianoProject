using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -2)
        {
            Destroy(this.gameObject);
        }
    }
}
