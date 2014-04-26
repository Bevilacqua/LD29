using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {
	public GameObject terrain;
	// Use this for initialization
	void Start () {
		for(int x = -10 ; x < 10 ; x++) { //Testing please redo this for the love of god
			for(int y = -5 ; y < 10 ; y++) {
				Instantiate(terrain , new Vector2(x + 0.5f + (0.5f * terrain.transform.lossyScale.x) , y  + (0.5f * terrain.transform.lossyScale.y)) , gameObject.transform.rotation);
				Instantiate(terrain , new Vector2(x + (0.5f * terrain.transform.lossyScale.x) , y  + 0.5f + (0.5f * terrain.transform.lossyScale.y)) , gameObject.transform.rotation);
				Instantiate(terrain , new Vector2(x + 0.5f + (0.5f * terrain.transform.lossyScale.x) , y  + 0.5f + (0.5f * terrain.transform.lossyScale.y)) , gameObject.transform.rotation);
				Instantiate(terrain , new Vector2(x + 0.5f * terrain.transform.lossyScale.x, y  + 0.5f * terrain.transform.lossyScale.y) , gameObject.transform.rotation);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
