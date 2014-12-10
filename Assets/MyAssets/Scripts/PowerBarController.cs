using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PowerBarController : MonoBehaviour {
	public Texture2D tex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
	//	GUI.DrawTextureWithTexCoords(new Rect(Screen.width - 150, 50, 100, Screen.height - 100), tex, new Rect(0, 0, 100f / 120, 700f / 120));
	}
}
