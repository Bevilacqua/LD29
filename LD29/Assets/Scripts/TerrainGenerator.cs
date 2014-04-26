using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {
	public GameObject upperLevelDirt;
	public GameObject midLevelRock;
	public GameObject lowLevelRock;

	// Use this for initialization
	void Start () {
		for(int x = -10 ; x < 10 ; x++) { //Testing please redo this for the love of god
			for(int y = -5 ; y < 10 ; y++) {
				if(y < 0) {
					Instantiate(lowLevelRock , new Vector2(x + 0.5f + (0.5f * lowLevelRock.transform.lossyScale.x) , y  + (0.5f * lowLevelRock.transform.lossyScale.y)) , gameObject.transform.rotation);
					Instantiate(lowLevelRock , new Vector2(x + (0.5f * lowLevelRock.transform.lossyScale.x) , y  + 0.5f + (0.5f * lowLevelRock.transform.lossyScale.y)) , gameObject.transform.rotation);
					Instantiate(lowLevelRock , new Vector2(x + 0.5f + (0.5f * lowLevelRock.transform.lossyScale.x) , y  + 0.5f + (0.5f * lowLevelRock.transform.lossyScale.y)) , gameObject.transform.rotation);
					Instantiate(lowLevelRock , new Vector2(x + 0.5f * lowLevelRock.transform.lossyScale.x, y  + 0.5f * lowLevelRock.transform.lossyScale.y) , gameObject.transform.rotation);
				} else if(y < 7) {
					Instantiate(midLevelRock , new Vector2(x + 0.5f + (0.5f * midLevelRock.transform.lossyScale.x) , y  + (0.5f * midLevelRock.transform.lossyScale.y)) , gameObject.transform.rotation);
					Instantiate(midLevelRock , new Vector2(x + (0.5f * midLevelRock.transform.lossyScale.x) , y  + 0.5f + (0.5f * midLevelRock.transform.lossyScale.y)) , gameObject.transform.rotation);
					Instantiate(midLevelRock , new Vector2(x + 0.5f + (0.5f * midLevelRock.transform.lossyScale.x) , y  + 0.5f + (0.5f * midLevelRock.transform.lossyScale.y)) , gameObject.transform.rotation);
					Instantiate(midLevelRock , new Vector2(x + 0.5f * midLevelRock.transform.lossyScale.x, y  + 0.5f * midLevelRock.transform.lossyScale.y) , gameObject.transform.rotation);
				} else {
					Instantiate(upperLevelDirt , new Vector2(x + 0.5f + (0.5f * upperLevelDirt.transform.lossyScale.x) , y  + (0.5f * upperLevelDirt.transform.lossyScale.y)) , gameObject.transform.rotation);
					Instantiate(upperLevelDirt , new Vector2(x + (0.5f * upperLevelDirt.transform.lossyScale.x) , y  + 0.5f + (0.5f * upperLevelDirt.transform.lossyScale.y)) , gameObject.transform.rotation);
					Instantiate(upperLevelDirt , new Vector2(x + 0.5f + (0.5f * upperLevelDirt.transform.lossyScale.x) , y  + 0.5f + (0.5f * upperLevelDirt.transform.lossyScale.y)) , gameObject.transform.rotation);
					Instantiate(upperLevelDirt , new Vector2(x + 0.5f * upperLevelDirt.transform.lossyScale.x, y  + 0.5f * upperLevelDirt.transform.lossyScale.y) , gameObject.transform.rotation);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
