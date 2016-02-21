using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	void Start () {
        Fader.instance.WhiteIn(1.0f);
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayBGM(5);
	}

	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            // Application.LoadLevel("Game");
            SoundManager.Instance.PlaySE((int)Random.Range(0, 1));
            Fader.instance.BlackOut(1.0f, "Description");
        }
	}
}
