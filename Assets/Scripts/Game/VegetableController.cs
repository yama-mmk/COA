using UnityEngine;
using System.Collections;

public class VegetableController : MonoBehaviour {

    public float speed;

    public enum Type {
        TYPE1 = 0,
        TYPE2 = 1,
    };

    public Type type = Type.TYPE1;

	void Update () {
        if (type == Type.TYPE1) {
            gameObject.transform.Translate(new Vector2(speed * -0.01f, 0));
        } else {
            gameObject.transform.Translate(new Vector2(0, speed * 0.01f));
        }
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Boss") {
			Debug.Log ("Vegirtable Collision");

			Destroy (gameObject);
		}
	}
}
