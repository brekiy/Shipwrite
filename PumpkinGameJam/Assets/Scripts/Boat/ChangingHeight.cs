using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingHeight : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    //float rotate = 0.2f * Mathf.Sin(Time.time * 4);
		this.transform.localPosition = new Vector3(this.transform.localPosition.x, 
                ScrollingWater.Y_VALUE + ScrollingWater.WATER_OFFSET + .125f, this.transform.localPosition.z);
    //if (Input.GetKeyDown(KeyCode.RightArrow)) rotate -= 0.05f;
    //this.transform.Rotate(new Vector3(this.transform.rotation.x,
      //this.transform.rotation.y, rotate));
	}
}
