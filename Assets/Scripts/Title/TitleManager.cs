using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	void Start () {
        Fader.instance.WhiteIn(1.0f);
	}

	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            // Application.LoadLevel("Game");
            Fader.instance.BlackOut(1.0f, "Description");
        }
	}
}
