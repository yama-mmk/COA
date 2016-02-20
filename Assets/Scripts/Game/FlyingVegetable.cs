using UnityEngine;
using System.Collections;

public class FlyingVegetable : MonoBehaviour {

	public enum Type {
		UP=0,
		DOWN=1,
	};

	public Type type = Type.UP;
	
	void Start(){
	}

	// Update is called once per frame
	void Update () {
		switch (type) {
		case Type.UP:
			Vector2 vec1 = transform.position;
			vec1.x += -0.1f;
			vec1.y += -0.1f;
			transform.position = vec1;
			break;
		case Type.DOWN:
			Vector2 vec2 = transform.position;
			vec2.x += -0.1f;
			vec2.y += -0.1f;
			transform.position = vec2; 
			break;
		default:
			break;
		}
	}
}
