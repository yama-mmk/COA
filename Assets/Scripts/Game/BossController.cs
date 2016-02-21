using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
	public GameObject Slash;
	private GameManager manager;
	private float time  = 0.0f;
	private float readyTime;
	private bool gameOver = false;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		readyTime = manager.READY_TIME;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time < readyTime){
			transform.Translate(new Vector2(2.0f * Time.deltaTime, 0.0f));
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (Slash != null && other.gameObject.tag == "Vegetable") {
			if(!gameOver){
				SoundManager.Instance.PlaySE (Random.Range (0,3) + 3);
			}
            Instantiate(Slash,
                        other.transform.position + new Vector3(-0.5f, 0.0f, 0.0f),
                        Quaternion.identity);
		} 

        if (Slash != null && other.gameObject.tag == "Player") {
			gameOver = true;
            Instantiate(Slash,
                        other.transform.position + new Vector3(-0.5f, 0.0f, 0.0f),
                        Quaternion.identity);
        }
	}



}
