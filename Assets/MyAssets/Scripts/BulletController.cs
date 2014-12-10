using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public bool breath = true;
	public int interval = 180;
	public float scale = 0.025f;

	public AssetsServer.Charactor charactor;
	public bool nakigao = false;

	private Vector3 savedScale;
	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		ReloadSprite();

		savedScale = transform.localScale;
	}

	public void ReloadSprite()
	{
		renderer = GetComponent<SpriteRenderer>();

		Texture2D texture;
		if (nakigao)
		{
			Debug.Log(AssetsServer.instance + ":" + (int)charactor);
			texture = AssetsServer.instance.charactorTextures2[(int)charactor];
		}
		else
		{
			texture = AssetsServer.instance.charactorTextures[(int)charactor];
		}
		renderer.sprite = Sprite.Create(texture,
			new Rect(0, 0, texture.width, texture.height),
			new Vector2(0.5f, 0.5f));
	}
	
	// Update is called once per frame
	void Update () {
		if (breath) { 
			var v = savedScale;
			v.y = (1 - scale*2 + MyMath.NSin(MyMath.frameIn(interval)) * scale + scale) * savedScale.y;
			transform.localScale = v;
		}
		

	}
}
