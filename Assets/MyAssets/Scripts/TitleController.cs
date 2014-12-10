using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {
	public GameObject labelObject;
	public GameObject game;
	public GameObject mainCameraObject;
	private Camera titleCamera;
	private Camera mainCamera;
	public GameObject uis;
	private GUILabel label;

	public Material[] scrollMaterials;
	public int scrollSpeed = 30; // frame per scroll
	private int scrollCounter;

	// Use this for initialization
	void Start () {
		label = labelObject.GetComponent<GUILabel>();
		titleCamera = this.GetComponentInChildren<Camera>();
		mainCamera = mainCameraObject.camera;

		uis.SetActive(false);

		if (titleCamera == null) Debug.LogError("Unassigned");
		if (mainCamera == null) Debug.LogError("Unassigned");
	}
	
	// Update is called once per frame
	void Update () {
		if(scrollCounter++ > scrollSpeed) scrollCounter = 0;
		foreach(var mat in scrollMaterials) {
			mat.mainTextureOffset = new Vector2(scrollCounter / (float)scrollSpeed, 0);
		}
	}

	void OnGUI() {
		Rect pos = new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 100);
		if (!game.activeSelf && GUI.Button(pos, "Play", label.style))
		{
			game.SetActive(true);
			game.GetComponent<GameController>().play = false;
			mainCamera = game.GetComponentInChildren<Camera>();
			mainCamera.gameObject.SetActive(false);
			titleCamera.transform.positionTo(1f, mainCamera.transform.position);
			var a = Go.to(titleCamera.camera, 1f, new GoTweenConfig()
				.floatProp("orthographicSize", mainCamera.camera.orthographicSize));
			a.easeType = GoEaseType.QuartIn;
			a.setOnCompleteHandler((b) =>
			{
				this.gameObject.SetActive(false);
				game.GetComponent<GameController>().play = true;
				uis.SetActive(true);
				mainCamera.gameObject.SetActive(true);
				Debug.Log("Anim fin");
			} );
				
		}

	}
}
