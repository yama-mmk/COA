using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
	public GameObject Slash;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (Slash != null && other.gameObject.tag == "Vegetable") {
			Debug.Log ("Boss Collision Vegetable");
			Instantiate (Slash,
			            other.transform.position,
			            Quaternion.identity);
		}
	}



}
