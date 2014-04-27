using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D collider) {
		player.GetComponent<Player>().onLadder = true;
	}
	
}
