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

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition) , Vector2.zero);

		if(Input.GetMouseButtonDown(0)) {
			if(hit.collider != null) {
				if(hit.collider.gameObject.tag == ("Stone")) {
					Destroy(hit.collider.gameObject); //TODO: this should reduce hit points of rock and have some visual effect a few hits should destroy it.
				}
			}
		}

	}

	void FixedUpdate() {
		if(Input.GetKey(KeyCode.LeftArrow)) {
			rigidbody2D.AddForce(new Vector2(-5f , 0.01f));	
		}else if(Input.GetKey(KeyCode.RightArrow)) {
			rigidbody2D.AddForce(new Vector2(5f , 0.01f));
		}
	}
}
