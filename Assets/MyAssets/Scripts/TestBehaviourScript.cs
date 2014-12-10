using UnityEngine;
using System.Collections;

public class TestBehaviourScript : MonoBehaviour
{

	public float power = 2000;
	public float deg = 45;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		gameObject.name = "(" + rigidbody2D.angularVelocity + ":" + rigidbody2D.velocity + ")";
		if (Mathf.FloorToInt(rigidbody2D.velocity.y) == 0)
		{
			rigidbody2D.angularDrag = 1f;
		}
		else
		{
			rigidbody2D.angularDrag = 0f;
		}
		if (Mathf.Abs(rigidbody2D.angularVelocity) < 20)
		{
			rigidbody2D.angularDrag = 4;
		}
		rigidbody2D.gravityScale = 3;
		if (deg > 45)
		{
			rigidbody2D.gravityScale += 1.5f * Mathf.Sin((deg - 45) * 2 * Mathf.Deg2Rad);
		}
	}

	void OnGUI()
	{
	/*
		float p1 = Mathf.Sin(deg * Mathf.Deg2Rad) * power, p2 = Mathf.Cos(deg * Mathf.Deg2Rad) * power;

		if (GUI.Button(new Rect(0, 120, 100, 30), "go(" + p1 + ":" + p2 + ")"))
		{
			Shoot(1, 1);
		}
		else if (GUI.Button(new Rect(0, 150, 100, 30), "reset"))
		{
			Reset();
		}*/
	}

	public void Shoot(float rate, float ang)
	{
		float p1 = Mathf.Sin(deg * ang * Mathf.Deg2Rad) * power * rate, p2 = Mathf.Cos(deg * ang * Mathf.Deg2Rad) * power * rate;

		gameObject.rigidbody2D.AddForce(new Vector2(p2, p1));
		gameObject.rigidbody2D.AddTorque(360 * -4);

	}

	public void Reset()
	{
		gameObject.transform.localPosition = new Vector3();
		gameObject.transform.localRotation = new Quaternion();
		gameObject.rigidbody2D.velocity = new Vector2();
		gameObject.rigidbody2D.angularVelocity = 0;

	}
}
