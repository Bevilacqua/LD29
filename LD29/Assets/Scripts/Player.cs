using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int maxSpeed = 5;
	// Use this for initialization
	void Start () {
		Camera.main.transform.position = new Vector3(transform.position.x , transform.position.y , Camera.main.transform.position.z);
	}
	
	void Update () {
		Camera.main.transform.position = new Vector3(transform.position.x , transform.position.y , Camera.main.transform.position.z);

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition) , Vector2.zero);

		if(Input.GetMouseButtonDown(0)) {
			if(hit.collider != null) {
				if(hit.collider.gameObject.tag == ("Stone")) {
					if(Mathf.Abs(hit.collider.gameObject.transform.position.x - transform.position.x) < .75f &&  Mathf.Abs(hit.collider.gameObject.transform.position.x - transform.position.x) < .75f) {
						Destroy(hit.collider.gameObject); //TODO: this should reduce hit points of rock and have some visual effect a few hits should destroy it.
					}
				}
			}
		}

	}

	void FixedUpdate() {
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			if(rigidbody2D.velocity.x > -maxSpeed)
				rigidbody2D.AddForce(new Vector2(-5f , 0.01f));	
		}else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			if(rigidbody2D.velocity.x < maxSpeed)
			rigidbody2D.AddForce(new Vector2(5f , 0.01f));
		}
	}
}
