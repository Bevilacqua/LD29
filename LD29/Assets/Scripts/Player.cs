using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Camera camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.FindObjectOfType<Camera>();
		camera.transform.position = new Vector3(transform.position.x , transform.position.y , camera.transform.position.z);

	}
	
	void Update () {
		camera.transform.position = new Vector3(transform.position.x , transform.position.y , camera.transform.position.z);


	}

	void FixedUpdate() {
		if(Input.GetKey(KeyCode.LeftArrow)) {
			rigidbody2D.AddForce(new Vector2(-5f , 0.01f));	
		}else if(Input.GetKey(KeyCode.RightArrow)) {
			rigidbody2D.AddForce(new Vector2(5f , 0.01f));
		}
	}
}
