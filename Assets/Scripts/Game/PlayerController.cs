using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float RecoverySpeed = 1.0f;
	public float jumpSpeed = 30f;
	public float defaultPosition = 0;
	public int defaultJumpCount = 2; 
	public GameObject textObject;
	private GameManager manager;
	private float time  = 0.0f;
	private float readyTime;
	private bool collisionPoison = false;
	private float damageTime = 0.0f;
	
    private bool dead = false;

	Rigidbody2D rb;
	int jumpCount;

    private Animator animator;

	void Start () {
        dead = false;
		rb = GetComponent<Rigidbody2D> ();
		jumpCount = defaultJumpCount;
		manager = GameObject.Find ("GameManager").GetComponent<GameManager> (); 
        animator = gameObject.GetComponent<Animator>();
		readyTime = manager.READY_TIME;
		textObject.SetActive (false);
	}
	
	void Update () {

		time += Time.deltaTime;

        if (!dead) {
		//ready
		if (time < readyTime / 2.0f) {
			transform.Translate (new Vector2 (4.0f * Time.deltaTime, 0.0f));
		
			//text appear
		} else if (time < readyTime) {
			textObject.SetActive (true);

			//game start
		} else if (!collisionPoison) {
			Destroy (textObject);
			if (Input.GetButtonDown ("Fire1") && jumpCount > 0) {
				SoundManager.Instance.PlaySE (2);
				JumpAction ();
				animator.SetTrigger ("Jump");
			}

			if (transform.position.x < defaultPosition) {
				rb.velocity = new Vector2 (RecoverySpeed, rb.velocity.y);
			}

			if (rb.velocity.y < -0.01f) {
				animator.SetFloat ("JumpVal", -1.0f);
			} else if (rb.velocity.y > 0.01f) {
				animator.SetFloat ("JumpVal", 1.0f);
			}
		} else {
			damageTime += Time.deltaTime;
			if(damageTime > 1.0f){
				// animator.SetTrigger ("Recovery");
				collisionPoison = false;
				damageTime = 0.0f;
			}
		}
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
			SoundManager.Instance.PlaySE (6);
			animator.SetTrigger ("Col");
            dead = true;
			manager.GameOver ();
		}
		if (other.gameObject.tag == "Vegetable") {
			jumpCount = defaultJumpCount;
		}
		if (other.gameObject.tag == "Poison"){
            animator.SetTrigger("PoisonCol");
			collisionPoison = true;
		}

	}



}
