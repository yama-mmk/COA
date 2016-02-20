using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Application.LoadLevel("Game");
        }
	}
}
