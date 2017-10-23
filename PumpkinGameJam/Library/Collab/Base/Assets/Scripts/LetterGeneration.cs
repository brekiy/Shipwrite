using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGeneration : MonoBehaviour {

  public GameObject letterObject;
	public char[] letters = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
		'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
  public char[] vowels = { 'A', 'E', 'I', 'O', 'U' };
	public float startDelay;
  private float delay;
  private int layer;
	public float yValue;
	public float minDelay;

	public float colSize = 10f;

    // Use this for initialization
    void Start()
    {
		  delay = 3f;
      layer = gameObject.layer;
      StartCoroutine(PeriodicSpawn());
		  StartCoroutine(ChangeDelay ());
    }


    IEnumerator PeriodicSpawn()
    {

        while (!GameController.instance.gameOver)
        {
			//if (delay > minDelay) {
			///	delay -= 1f / ((Time.time + 1) * 4);
			//}
            yield return new WaitForSeconds(delay);
            SpawnLetter();

        }
    }

	IEnumerator ChangeDelay(){
		float tempDelay = 10;
		while (!GameController.instance.gameOver) {
			yield return new WaitForSeconds(tempDelay);
			tempDelay += 5f;

			if (delay > minDelay) {
				delay /= 1.3f;
			}
		}
	}
		

  void SpawnLetter(){
    int letterNum = 0;
    bool vowel = false;
    //Choose vowels only or entire alphabet
    if (Random.Range(0, 4) < 1) {
      //about 25% chance of being vowel subset only
      letterNum = Random.Range(0, 4);
      vowel = true;
    }
    else letterNum = Random.Range(0, 25);
    
    //Create letter instance
    GameObject spawned = Instantiate(letterObject, this.transform);

    //Set text
    char letterText;
    if (vowel) letterText = vowels[letterNum];
    else letterText = letters[letterNum];
    spawned.GetComponent<TextMesh>().text = letterText.ToString();

		spawned.GetComponent<BoxCollider2D> ().size = new Vector2 (7.87f, 10f);
		spawned.GetComponent<BoxCollider2D> ().offset = new Vector2 (4f, -8f);

		spawned.GetComponent<LetterMovement> ().letter = letterText;

		yValue = Random.Range(-3f, 2f);

		spawned.transform.position = new Vector3(17f, yValue, 0f);
		spawned.layer = 31;
		spawned.transform.localScale = new Vector2 (0.065f, 0.065f);

        //var parent = transform.parent;
		var renderer = spawned.GetComponent<TextMesh>();

		renderer.offsetZ = 1;

    }
}
