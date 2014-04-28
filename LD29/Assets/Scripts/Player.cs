using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int maxSpeed = 5;

	public GameObject ladder;
	public GameObject drill;

	private Animator animator;
	
	//Jewls:
	public GameObject diamond; //100
	public GameObject redGem; //10
	public GameObject emerald; //55

//	[HideInInspector]
	public bool onLadder;

	public int money = 0;
	// Use this for initialization
	void Start () {
		Camera.main.transform.position = new Vector3(transform.position.x , transform.position.y , Camera.main.transform.position.z);
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		GameObject.Find("Money").GetComponent<GUIText>().text = "$ " + money;
		Camera.main.transform.position = new Vector3(transform.position.x , transform.position.y , Camera.main.transform.position.z);

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition) , Vector2.zero);

		if(Input.GetMouseButtonDown(1) && money >= 50) { 
			if(hit.collider != null) {
				if(hit.collider.tag == ("Stone")) {
					if(Mathf.Abs(hit.collider.gameObject.transform.position.x - transform.position.x) < .75f &&  Mathf.Abs(hit.collider.gameObject.transform.position.y - transform.position.y) < .75f) {
						Instantiate(drill , hit.collider.gameObject.transform.position , transform.rotation);
						money -= 50;
						Destroy(hit.collider.gameObject);
					}
				}
			}
		}

		if(Input.GetMouseButtonDown(0)) {
			if(hit.collider != null) {
				if(hit.collider.gameObject.tag == ("Stone")) {
					if(Mathf.Abs(hit.collider.gameObject.transform.position.x - transform.position.x) < .75f &&  Mathf.Abs(hit.collider.gameObject.transform.position.y - transform.position.y) < .75f) {

						hit.collider.gameObject.GetComponent<StoneHandler>().AddCrack();

						if(hit.collider.gameObject.GetComponent<StoneHandler>().readyToBeDestroyed) {
							if(hit.collider.gameObject.transform.position.y - transform.position.y < -0.25f) {
								Instantiate(ladder , hit.collider.gameObject.transform.position , hit.collider.gameObject.transform.rotation);
							} else { //Gems should go in order of best to worst
								
								if(transform.position.x < -1) { //Best gems

									if(Random.Range(0,45) == 15)
										Instantiate(diamond , hit.collider.gameObject.transform.position , transform.rotation);
									else if(Random.Range(0,5) == 3) 
										Instantiate(redGem , hit.collider.gameObject.transform.position , transform.rotation);

									if(transform.position.x < -2)
										if(Random.Range(0,100) % 3 == 0)
											Instantiate(emerald , hit.collider.gameObject.transform.position , transform.rotation);

									
								} else if(transform.position.x < 7) { //Medium

									if(Random.Range(0,50) == 15)
										Instantiate(diamond , hit.collider.gameObject.transform.position , transform.rotation);
									else if(Random.Range(0,5) == 3) 
										Instantiate(redGem , hit.collider.gameObject.transform.position , transform.rotation);
									else if(Random.Range(0,100) % 3 == 0)
										Instantiate(emerald , hit.collider.gameObject.transform.position , transform.rotation);

								} else { //Worst

									if(Random.Range(0 , 100) == 15) 
										Instantiate(emerald , hit.collider.gameObject.transform.position , transform.rotation);
									else if(Random.Range(0,100) % 2 == 0)
										Instantiate(redGem , hit.collider.gameObject.transform.position , transform.rotation);
								}

							}

							hit.collider.gameObject.GetComponent<StoneHandler>().DestroyEverything();
						}
					//	Destroy(hit.collider.gameObject); //TODO: this should reduce hit points of rock and have some visual effect a few hits should destroy it.
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

		if(rigidbody2D.velocity.x != 0f) {
			animator.SetBool("moving" , true);
		} else {
			animator.SetBool("moving" , false);
		}
	}
	
}
