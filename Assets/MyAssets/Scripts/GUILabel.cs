using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUILabel : MonoBehaviour
{
	public GUIStyle style;
	public string text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		var rect = new Rect(transform.position.x, transform.position.y,
			transform.localScale.x, transform.localScale.y);
		GUI.Label(rect, text, style);
	}

	public void Blink(int dur, Color col)
	{
		StartCoroutine(BlinkCoroutine(dur, col));
	}

	public IEnumerator BlinkCoroutine(int dur, Color col)
	{
		Debug.Log("OK1");
		for (int i = 0; i < dur; i++)
		{
			style.normal.textColor = col;
			yield return new WaitForSeconds(0.05f);
			style.normal.textColor = Color.white;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
