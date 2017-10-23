using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour {

	public GameObject cloudObject;
	public Sprite[] clouds;
	public float delay;

	void Start(){
		StartCoroutine(PeriodicSpawn(delay));
	}

	IEnumerator PeriodicSpawn(float delay){
		while (!GameController.instance.gameOver)
		{
			yield return new WaitForSeconds(delay);
			spawnCloud();
		}
	}





	void spawnCloud(){
		GameObject spawned = Instantiate(cloudObject, this.transform);

		int randCloud = Random.Range(0, 2);

		spawned.GetComponent<SpriteRenderer>().sprite = (clouds [randCloud]);

		spawned.transform.position = new Vector2(-10f, Random.Range(1.8f,5.0f));

		spawned.transform.localScale = new Vector2 (Random.Range(2,4), Random.Range(2,4));
		delay = Random.Range(2.4f, 8.7f);
	}
}