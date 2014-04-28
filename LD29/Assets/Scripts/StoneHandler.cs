using UnityEngine;
using System.Collections;

public class StoneHandler : MonoBehaviour {
	public Sprite smallCrack;
	public Sprite medCrack;
	public Sprite largeCrack;
	public int index = 0;

	public bool readyToBeDestroyed = false;

	public GameObject Crack;
	private GameObject localCrack;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DestroyEverything() {
		Destroy(localCrack);
		Destroy(gameObject);
	}

	public void AddCrack() {
		//TODO: Sound effect

		if(index == 0) {
			localCrack = Instantiate(Crack , gameObject.transform.position , gameObject.transform.rotation) as GameObject;
			localCrack.GetComponent<SpriteRenderer>().sprite = medCrack;
		} else if(index == 1) {
			localCrack.GetComponent<SpriteRenderer>().sprite = largeCrack;
		} else {
			readyToBeDestroyed = true;
		}

		index++;

	}
}
