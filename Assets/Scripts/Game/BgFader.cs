using UnityEngine;
using System.Collections;

public class BgFader : MonoBehaviour {
	private float fadeTime = 20f;
	private GameManager manager;
	private float readyTime;
	private float currentRemainTime;
	private float time = 0.0f;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find("GameManager").GetComponent<GameManager>();
		readyTime = manager.READY_TIME;
		currentRemainTime = fadeTime;

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > readyTime) {
			currentRemainTime -= Time.deltaTime;
		
			if (currentRemainTime <= 0f) {
				// 残り時間が無くなったら自分自身を消滅
				GameObject.Destroy (gameObject);
				return;
			}
			float alpha = currentRemainTime / fadeTime;
			this.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, alpha);
		}
	}
}
