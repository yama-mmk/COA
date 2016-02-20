using UnityEngine;
using System.Collections;

public class VegetableController : MonoBehaviour {

    public float speed = 3f;

	void Start () {
	
	}

	void Update () {
        gameObject.transform.Translate(new Vector2(speed * -0.01f, 0));
	}
}
