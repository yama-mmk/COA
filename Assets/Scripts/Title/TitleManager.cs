using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	void Start () {
        Fader.instance.WhiteIn(1.0f);
        SoundManager.Instance.PlayBGM(1);
	}

	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            // Application.LoadLevel("Game");
            SoundManager.Instance.StopBGM();
            Fader.instance.BlackOut(1.0f, "Description");
        }
	}
}
