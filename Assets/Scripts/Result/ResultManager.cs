using UnityEngine;
using System.Collections;

public class ResultManager : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Application.LoadLevel("Title");
        }
	}
}
