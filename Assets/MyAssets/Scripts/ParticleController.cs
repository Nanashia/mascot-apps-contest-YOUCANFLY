using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleController : MonoBehaviour
{
	private ParticleSystem particle;

	// Use this for initialization
	void Start()
	{
		particle = GetComponent<ParticleSystem>();
		particle.Stop(); 

		StartCoroutine(ControlCoroutine());
	}

	// Update is called once per frame
	void Update()
	{
	}

	IEnumerator ControlCoroutine()
	{
		yield return null;
		Rigidbody2D rigid2d = GameController.instance.bulletObject.rigidbody2D;

		while(true) {
			Debug.Log("OK");
			while (Mathf.FloorToInt(rigid2d.velocity.y) == 0) yield return null;

			Debug.Log("OK2");
			particle.Play();

			while (Mathf.FloorToInt(rigid2d.velocity.y) > 0 ||
				Mathf.FloorToInt(rigid2d.transform.localPosition.y) > 0) yield return null;

			Debug.Log("OK3");
			particle.Stop();

			while (Mathf.FloorToInt(rigid2d.velocity.x) > 0) yield return null;
		}
	}
}
