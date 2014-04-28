using UnityEngine;
using System.Collections;

public class Jewl : MonoBehaviour {
	public int value; //TO be determined by prefab
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D collision) {
		if(collision.gameObject.tag == "Player") {
			GameObject.Find("Player").GetComponent<Player>().money += value;
			Destroy(gameObject);
		}

		if(collision.gameObject.tag == "Drill") {
			GameObject.Find("Player").GetComponent<Player>().money += value;
			Destroy(gameObject);
		}

	}
}
