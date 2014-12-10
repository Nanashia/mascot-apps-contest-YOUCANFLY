using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUILabel))]
[ExecuteInEditMode]
public class ScoreGUI : MonoBehaviour {
	public GUILabel label;
	public GameObject trackTarget;

	public bool visible = true;
	public float value = 100f;

	public bool blink = false;
	public Color col;

	// Use this for initialization
	void Start () {
		label = GetComponent<GUILabel>();
	}

	// Update is called once per frame
	void Update()
	{

		value = trackTarget.transform.localPosition.x;


		if (!trackTarget) Debug.LogError("Unassigned.");
		string s = format(value, 64);
		label.text = s;

	}

	public static string format( float value, int size)
	{
		int floor = (int)Mathf.Floor(Mathf.Abs(value));
		int po = (int)((value - floor) * 100);
		return "<size=" + size * 2 + ">" + floor + "</size>" +
			"<size=" + size + ">," + string.Format("{0:00}", po) + "</size>m";
	}

}
