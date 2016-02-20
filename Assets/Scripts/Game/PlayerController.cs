using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 1.0f;
	public float jumpSpeed = 30f;
	public int defaultJumpCount = 2; 

	Rigidbody2D rb;
	int jumpCount;
		// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		jumpCount = defaultJumpCount;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1") && jumpCount > 1) {
			jumpAction ();
		}
	}


	//jump
	void jumpAction(){
		rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
		jumpCount--;
	}


	void OnCollisionStay2D(Collision2D collision){
		if (collision.gameObject.tag == "Floor") {
				jumpCount = defaultJumpCount;
		}
	}

}
