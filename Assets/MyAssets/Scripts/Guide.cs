using UnityEngine;
using System.Collections;

public class Guide : MonoBehaviour {

	private Vector3 savedPosition;

	// Use this for initialization
	void Start () {
		savedPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (name == "Arrow")
		{
			var label = GetComponent<GUILabel>();
			label.transform.Translate(MyMath.NCos(MyMath.frameIn(60)), 0, 0);
			
		}
	}
}
