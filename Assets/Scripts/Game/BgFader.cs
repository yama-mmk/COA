using UnityEngine;
using System.Collections;

public class BgFader : MonoBehaviour {
	private float fadeTime = 5f;
	private VegetableGenerator generator;
	private float level;
	private float currentRemainTime;
	private float time = 0.0f;
	// Use this for initialization
	void Start () {
		generator = GameObject.Find("VegetableGenerator").GetComponent<VegetableGenerator>();
		level = (int)(generator.level);
		currentRemainTime = fadeTime;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 3.0f) {
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
