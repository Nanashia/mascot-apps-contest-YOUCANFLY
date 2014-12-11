using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GameController : MonoBehaviour {
	public static GameController instance;

	public GameObject bulletObject;
	public GameObject highScoreObject;

	public static float highScore = -1;
	public bool isUpdated = false;

	public enum State {
		   POW, ANG, SHOOT
	}
	public State state;

	int powerBarHeight = 0;

	public bool play = true;


	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

		score.SetActive(false);

		Debug.Log("Start");
		state = State.POW;

		shuffleCharactor();
	}
	
	// Update is called once per frame
	void Update () {
		if (state == State.SHOOT)
		{
			if (score.GetComponent<ScoreGUI>().value > highScore)
			{
				isUpdated = true;
				if (!isUpdated) { 

					var c = Color.Lerp(Color.red, Color.yellow, 0.5f);
					score.GetComponent<GUILabel>().Blink(1, c);
					highScoreObject.GetComponent<GUILabel>().Blink(1, c);
				}
				

				highScore = score.GetComponent<ScoreGUI>().value;
			}
			else { 
			 }


			// stop
			if (bullet.rigidbody2D.velocity.magnitude < 1)
			{
				bullet.rigidbody2D.velocity = new Vector2();
				bullet.rigidbody2D.angularVelocity = 0;

			}
			else if (bullet.rigidbody2D.velocity.magnitude < 5)
			{
				var bc = bullet.GetComponent<BulletController>();
				bc.nakigao = false;
				bc.ReloadSprite();
			}
		}
	}

	public Texture2D texture;
	public Texture2D cir;
	public float rate = 1;
	public float rate2 = 0.75f;

	public float ang = 0;

	public GameObject score;
	public GameObject bullet;


	public GUIStyle style;

	void OnGUI()
	{
		if (!play) return;

		if (0 < highScore)
		{
			highScoreObject.GetComponent<GUILabel>().text = 
				"high score: " + ScoreGUI.format(highScore, 32);
		}

		if (state == State.POW) { 
			rate = Mathf.Abs(MyMath.NSin(MyMath.frameIn(120)));

			drawBar(rate);

			if (GUI.Button(new Rect(300, 400, 200, 50), "POWER", style)) {
				state = State.ANG;
				Debug.Log(rate);
			}
		}
		if (state == State.ANG)
		{
			drawBar(rate);

			ang = Mathf.Abs((MyMath.frameIn(120) - 0.5f));
			ang = Mathf.PingPong(Time.time, 1);

			GUIUtility.RotateAroundPivot(ang*-90 + 45, new Vector2(400, 300));
			GUI.DrawTexture(new Rect(340, 240, 120, 120), cir);
			GUI.matrix = Matrix4x4.identity;

			GUI.Label(new Rect(50, 400, 200, 50), "POWER", style);
			GUI.Label(new Rect(50, 480, 200, 50), (int)(rate * 100) + "%", style);

			if (GUI.Button(new Rect(300, 400, 200, 50), "ANGLE", style))
			{
				state = State.SHOOT;
				bullet.GetComponent<TestBehaviourScript>().Shoot(rate, ang);

				bullet.GetComponent<BulletController>().nakigao = true;
				bullet.GetComponent<BulletController>().ReloadSprite();
				Debug.Log(ang);
			}
		}

		if (state == State.SHOOT)
		{
			score.SetActive(true);

			if (GUI.Button(new Rect(600, 20, 200, 50), "RETRY", style))
			{
				state = State.POW;
				shuffleCharactor();
				bullet.GetComponent<TestBehaviourScript>().Reset();
				isUpdated = false;
			}

			if (bullet.rigidbody2D.velocity.magnitude < 1)
			{
				var c = GUI.color;
				GUI.color = Color.cyan;
				if (GUI.Button(new Rect(600, 400, 200, 50), "Twitter", style))
				{
					Application.OpenURL(string.Format("http://twitter.com/share?url=http://pronama.github.io/mascot-apps-contest/2014/works.html?id=158&text=%23マスコットアプリ文化祭 YOU CAN FLY!で遊びました。（記録：{0:F2}m) ", score.GetComponent<ScoreGUI>().value));
				}
				GUI.color = c;
			}

			GUI.Label(new Rect(50, 400, 200, 50), "POWER", style);
			GUI.Label(new Rect(50, 480, 200, 50), (int)(rate * 100) + "%", style);

			GUI.Label(new Rect(300, 400, 200, 50), "ANGLE", style);
			GUI.Label(new Rect(300, 480, 200, 50), (int)(ang * 90) + " DEG", style);
		}

	}

	void drawBar(float rate)
	{
		var rect = new Rect(0, 0, rate2, rate * rate2 * 4);
		GUI.DrawTextureWithTexCoords(new Rect(600, 50 + 400 * (1 - rate), 100, 400 * rate), texture, rect);

	}

	void shuffleCharactor()
	{
		int i = Random.Range(0, 6);
		bullet.GetComponent<BulletController>().nakigao = false;
		bullet.GetComponent<BulletController>().charactor = (AssetsServer.Charactor)i;
		bullet.GetComponent<BulletController>().ReloadSprite();
	}
}
