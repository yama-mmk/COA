using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameManager gameManager;
	public float RecoverySpeed = 1.0f;
	public float jumpSpeed = 30f;
	public float defaultPosition = 0;
	public int defaultJumpCount = 2; 
	
	Rigidbody2D rb;
	int jumpCount;
		// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		jumpCount = defaultJumpCount;
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> (); 
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1") && jumpCount > 0) {
			JumpAction ();
		}

		if (transform.position.x < defaultPosition) {
			rb.velocity = new Vector2(RecoverySpeed, rb.velocity.y);
		}


	}


	//jump
	void JumpAction(){
		rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
		jumpCount--;
		Debug.Log ("jumpCount = " + jumpCount);
	}


	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Floor") {
			jumpCount = defaultJumpCount;
		}

		if (collision.gameObject.tag == "Boss") {
		//	gameManager.GameOver ();
		}
	}

}
