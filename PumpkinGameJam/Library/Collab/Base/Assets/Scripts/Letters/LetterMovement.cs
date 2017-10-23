using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMovement : MonoBehaviour {

	public char letter;
	public float sinTime = 10f;
	public float accelTime = 20f;
	public float maxSinRand = 20f;
	public float maxAccelRand = 25f;

	private int enableSin;
	private int enableAccel;
	private Rigidbody2D rBody;
	private TextMesh text;
	private bool sinMovement = false;
	private bool accelMovement = false;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody2D> ();
		rBody.velocity = new Vector2 (GameController.instance.scrollSpeed, 0);
		text = GetComponent<TextMesh> ();
		//sinTime *= 100f; //Get to seconds


		if (Time.timeSinceLevelLoad > sinTime) {

			int yRandSin = (int)Mathf.Clamp(Mathf.Ceil (maxSinRand - Time.timeSinceLevelLoad / 3), 7, maxSinRand);
			enableSin = Random.Range (0, yRandSin);

			if (enableSin == 2) {
				text.color = new Color (255, 215, 0); //Gold
				sinMovement = true;
			}
			else if (enableSin == 3) {
				text.color = Color.magenta;
				sinMovement = true;
			}

			else if (Time.timeSinceLevelLoad > accelTime) {
				int yRandAccel = (int)Mathf.Clamp(Mathf.Ceil (maxAccelRand - Time.timeSinceLevelLoad / 3), 7, maxAccelRand);
				enableAccel = Random.Range (0, yRandAccel);

				if (enableAccel == 2) {
					text.color = Color.grey;
					accelMovement = true;
				}

			}

		}
  }

  // Update is called once per frame
  void Update () {
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		if (pos.x < -5f) {
			Destroy (gameObject);
		}

		if (GameController.instance.gameOver) {
			rBody.velocity = Vector2.zero;
		} 
		else {
			if (sinMovement) {

				if (enableSin == 2) {
					rBody.velocity = Vector2.up * Mathf.Sin (Time.time * 6) * 15 + new Vector2 (GameController.instance.scrollSpeed, 0);
				} 
				else if (enableSin == 3) {
					rBody.velocity = Vector2.left * Mathf.Sin (Time.time * 6) * 15 + new Vector2 (GameController.instance.scrollSpeed, 0);
				}

			} 
			else if (accelMovement) {

				if (enableAccel == 2) {
					rBody.velocity -= new Vector2 (1.5f, 0) * Time.deltaTime;
				}
			}

		}
		
	}
		
}
