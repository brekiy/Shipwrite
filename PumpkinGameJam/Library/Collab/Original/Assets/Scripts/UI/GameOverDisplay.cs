﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour {

  Text textBox;
  // Use this for initialization
  void Start () {
    textBox = GetComponent<Text>();
  }
	
	// Update is called once per frame
	void Update () {
    if(GameController.instance.gameOver)
      textBox.text = "Game over!\r\nHit 'R' to restart, or Esc to go back to the main menu.";
  }
}
