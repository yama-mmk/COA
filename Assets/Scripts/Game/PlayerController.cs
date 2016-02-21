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

    private Animator animator;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		jumpCount = defaultJumpCount;
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> (); 
        animator = gameObject.GetComponent<Animator>();
	}
	
	void Update () {

		if (Input.GetButtonDown ("Fire1") && jumpCount > 0) {
            SoundManager.Instance.PlaySE(4);
			JumpAction ();
            animator.SetTrigger("Jump");
		}

		if (transform.position.x < defaultPosition) {
			rb.velocity = new Vector2(RecoverySpeed, rb.velocity.y);
		}

        if (rb.velocity.y < -0.01f) {
            animator.SetFloat("JumpVal", -1.0f);
        } else if (rb.velocity.y > 0.01f) {
            animator.SetFloat("JumpVal", 1.0f);
        }
	}

	//jump
	void JumpAction(){
		rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
		jumpCount--;
		// Debug.Log ("jumpCount = " + jumpCount);
	}


	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Floor") {
            // animator.SetTrigger("isGround");
            animator.SetFloat("JumpVal", 0.0f);
			jumpCount = defaultJumpCount;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Boss") {
			SoundManager.Instance.PlaySE(9);
			animator.SetTrigger("Col");
			gameManager.GameOver ();
		}
	}


}
