using UnityEngine;
using System.Collections;

public class VegetableController : MonoBehaviour {

    public float speed;
	public GameObject cutVegetable1;
	public GameObject cutVegetable2;

	private VegetableGenerator generator;
	private float level;
	private bool collisionPlayer = false;


    public enum Type {
        TYPE1 = 0,
        TYPE2 = 1,
    };

    public Type type = Type.TYPE1;

	void Start(){
		generator = GameObject.Find("VegetableGenerator").GetComponent<VegetableGenerator>();
		level = 1 + (int)(generator.level) * 0.8f;
	}
	
	
	void Update () {

        if (type == Type.TYPE1) {
            gameObject.transform.Translate(new Vector2(level * speed * -0.01f, 0));
        } else {
            gameObject.transform.Translate(new Vector2(0,level * speed * 0.01f));
        }
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Boss") {
			if(cutVegetable1 != null && cutVegetable2 != null){
			Instantiate (cutVegetable1,
			             transform.position + new Vector3 (0.0f, 0.2f, 0.0f),
			             Quaternion.identity);
			
			Instantiate (cutVegetable2,
			             transform.position + new Vector3 (0.0f, -0.2f, 0.0f),
			             Quaternion.identity);
			}

			Destroy (gameObject);
		}
		if (gameObject.tag == "Poison" && other.gameObject.tag == "Player") {
			if (!collisionPlayer) {
				other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-8.0f, 8.0f);
			}
			collisionPlayer = true;
		}


	}



}
