using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int maxSpeed = 5;

	public GameObject ladder;

//	[HideInInspector]
	public bool onLadder;
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
					if(Mathf.Abs(hit.collider.gameObject.transform.position.x - transform.position.x) < .75f &&  Mathf.Abs(hit.collider.gameObject.transform.position.y - transform.position.y) < .75f) {
						if(hit.collider.gameObject.transform.position.y - transform.position.y < -0.25f) {
							Instantiate(ladder , hit.collider.gameObject.transform.position , hit.collider.gameObject.transform.rotation);
						}

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

		if(Input.GetKeyDown(KeyCode.Space) && rigidbody2D.velocity.y == 0f) {
			rigidbody2D.AddForce(new Vector2(0f , 150f));
		}

		if((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && onLadder == true) {
				if(rigidbody2D.velocity.y < (maxSpeed * 3f))
					rigidbody2D.AddForce(new Vector2(0.01f , 12f));
		}

		onLadder = false; //Ensure that it is not kept on
	}
	
}
