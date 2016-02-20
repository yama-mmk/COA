using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {
	public float speed = 1.0f;
	public float startPosition;
	public float endPosition;
	
	// Use this for initialization
	void Update() {
		//transform floor to left
		transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

		if(transform.position.x <= endPosition) ScrollEnd();
	}

	void ScrollEnd(){
		transform.Translate (-1 * (endPosition - startPosition), 0, 0);
	}
}
