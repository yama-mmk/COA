using UnityEngine;
using System.Collections;

public class SlashController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("AutoDestroy", 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AutoDestroy(){
		Destroy (gameObject);
	}

}
