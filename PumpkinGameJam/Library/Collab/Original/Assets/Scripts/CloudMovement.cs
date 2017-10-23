using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(0.2f,1.1f), 0);

	}
	
	// Update is called once per frame
	void Update () {
    Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
    if (pos.x > 1) Destroy(gameObject);
    if (GameController.instance.gameOver == true)
			this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
}
