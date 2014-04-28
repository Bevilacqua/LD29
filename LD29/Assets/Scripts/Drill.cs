using UnityEngine;
using System.Collections;

public class Drill : MonoBehaviour {
	public float delay = 2f;
	private float elapsedTime = 0f;

	private Player playerScript;
	// Use this for initialization
	void Start () {
		playerScript = GameObject.Find("Player").GetComponent<Player>();
	}



	// Update is called once per frame
	void Update () {
		RaycastHit2D test = Physics2D.Raycast(transform.position + new Vector3( 0f , -0.2525f , 0f) , -Vector2.up);

		if(test.collider.gameObject.tag != "Stone") {
			test.collider.gameObject.transform.position = ( test.collider.gameObject.transform.position + new Vector3(0f , 1f , 0f));
		}

		if(elapsedTime >= delay) {
			RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3( 0f , -0.2525f , 0f) , -Vector2.up);

			if(hit.collider == null) {
				elapsedTime = 0f;
				return;
			}

			if(hit.collider.gameObject.tag != "Stone") {
				hit.collider.gameObject.transform.position = ( hit.collider.gameObject.transform.position + new Vector3(0f , 1f , 0f));
			}

			hit.collider.gameObject.GetComponent<StoneHandler>().AddCrack();

			if(hit.collider.gameObject.GetComponent<StoneHandler>().readyToBeDestroyed) {

				///
				if(transform.position.x < -1) { //Best gems
					
					if(Random.Range(0,45) == 15)
						Instantiate(playerScript.diamond , hit.collider.gameObject.transform.position , transform.rotation);
					else if(Random.Range(0,5) == 3) 
						Instantiate(playerScript.redGem , hit.collider.gameObject.transform.position , transform.rotation);
					
					if(transform.position.x < -2)
						if(Random.Range(0,100) % 3 == 0)
							Instantiate(playerScript.emerald , hit.collider.gameObject.transform.position , transform.rotation);
					
					
				} else if(transform.position.x < 7) { //Medium
					
					if(Random.Range(0,50) == 15)
						Instantiate(playerScript.diamond , hit.collider.gameObject.transform.position , transform.rotation);
					else if(Random.Range(0,5) == 3) 
						Instantiate(playerScript.redGem , hit.collider.gameObject.transform.position , transform.rotation);
					else if(Random.Range(0,100) % 3 == 0)
						Instantiate(playerScript.emerald , hit.collider.gameObject.transform.position , transform.rotation);
					
				} else { //Worst
					
					if(Random.Range(0 , 100) == 15) 
						Instantiate(playerScript.emerald , hit.collider.gameObject.transform.position , transform.rotation);
					else if(Random.Range(0,100) % 2 == 0)
						Instantiate(playerScript.redGem , hit.collider.gameObject.transform.position , transform.rotation);
				}

				///

				Instantiate(playerScript.ladder , hit.collider.gameObject.transform.position , hit.collider.gameObject.transform.rotation);

				hit.collider.gameObject.GetComponent<StoneHandler>().DestroyEverything();
			}

			elapsedTime = 0f;
		} else {
			elapsedTime += Time.deltaTime;
		}
	}
}
