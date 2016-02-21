
using UnityEngine;
using System.Collections;

public class DescriptionManager : MonoBehaviour {

    void Start() {
        Fader.instance.BlackIn(1.0f);
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            // Application.LoadLevel("Game");
            Fader.instance.BlackOut(1.0f, "Game");
        }
    }
}
