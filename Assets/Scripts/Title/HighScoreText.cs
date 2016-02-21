using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreText : MonoBehaviour {

    private Text text;

	void Start () {
        text = gameObject.GetComponent<Text>();

        text.text = "ハイスコア: " + PlayerPrefs.GetInt("High").ToString();
	}
}
