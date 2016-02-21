using UnityEngine;
using System.Collections;

public class FlyingVegetable : MonoBehaviour {
	public float speed = 0.05f;

	public enum Type {
		UP,
		DOWN,
	};

	public Type type = Type.UP;
	
	void Start(){
	}

	// Update is called once per frame
	void Update () {
		switch (type) {
		case Type.UP:
			Vector2 vec1 = transform.position;
			vec1.x += -speed;
			vec1.y += speed;
			transform.position = vec1;
			break;
		case Type.DOWN:
			Vector2 vec2 = transform.position;
			vec2.x += -speed;
			vec2.y += -speed;
			transform.position = vec2; 
			break;
		default:
			break;
		}
	}
}
