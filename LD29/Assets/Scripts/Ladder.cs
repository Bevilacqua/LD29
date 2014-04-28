using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
	private GameObject player;

	private bool disengage;
	private float delay = 0.4f;
	private float elapsedTime;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(disengage) {
			if(elapsedTime >= delay) {
				elapsedTime = 0f;
				player.GetComponent<Player>().onLadder = false;
				disengage = false;
			} else {
				elapsedTime += Time.deltaTime;
			}
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		if(collider.gameObject.tag == "Player")
			player.GetComponent<Player>().onLadder = true;
	}

	void OnTriggerExit2D(Collider2D collider) {
		if(collider.gameObject.tag == "Player")
			disengage = true;
	}

}
