using UnityEngine;
using System.Collections;

public class TransformTracker : MonoBehaviour {
	public GameObject target = null;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = target.transform.localPosition + offset;
	}
}
