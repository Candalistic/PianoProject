using UnityEngine;
using System.Collections;

public class SetLocationBasedOnTarget : MonoBehaviour {
    public Transform target;
    
    public int xDistance = 10;
	// Use this for initialization
	void Start () {
        transform.position = target.position;
        transform.position += Vector3.forward * xDistance;
        LineRenderer renderer = this.gameObject.GetComponent<LineRenderer>();
        renderer.SetPosition(0, transform.position);
        renderer.SetPosition(1, target.position);
	}
   /* void onDrawGismosSelected()
    {
        Transform[] args = { this.gameObject.transform, target};
        iTween.DrawLine(args, Color.white);
        iTween.DrawLineGizmos(args);
    }*/
}
