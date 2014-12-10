using UnityEngine;
using System.Collections;

public class AssetsServer : MonoBehaviour {
	public static AssetsServer instance;

	// Charactors
	public enum Charactor {
			Unity,
			Pronama,
			Query,
			Claudia,
			Conoha,
			Anzu
	}

	public static int texture = 6;
	public Texture2D[] charactorTextures = new Texture2D[texture];
	public Texture2D[] charactorTextures2 = new Texture2D[texture];

	public Texture2D[] charactorSpecials = new Texture2D[texture];
	public Texture2D[] charactorSpecialsHead = new Texture2D[texture];


	// GUI
	public Font cyber;
	public Font retro;

	void Awake()
	{
		instance = this;
	}
}
