using UnityEngine;
using System.Collections;

public class ResultManager : MonoBehaviour {

    int score = 0;

	void Start () {
        score = GameManager.final_value;
	}

	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Application.LoadLevel("Title");
        }
	}
}
