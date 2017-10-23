using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTrayDisplay : MonoBehaviour {

  Text textBox;
  BoatController boat;
  bool isBlinking = false;
  
	void Start () {
    textBox = GetComponent<Text>();
    boat = GameObject.Find("BoatWithRocking").GetComponentInChildren<BoatController>();
	}
	
	void Update () {
    if(!isBlinking)
      textBox.text = "Letters Collected:\n" + boat.letterTray.currString.ToUpper();
	}

  public IEnumerator BB() {
    while (isBlinking) {
      textBox.color = Color.red;
      yield return new WaitForSeconds(0.5f);
      textBox.color = Color.white;
      yield return new WaitForSeconds(0.5f);
    }
  }

  public IEnumerator BG() {
    while (isBlinking) {
      textBox.color = Color.green;
      yield return new WaitForSeconds(0.5f);
      textBox.color = Color.white;
      yield return new WaitForSeconds(0.5f);
    }
  }

  public IEnumerator BT() {
    isBlinking = true;
    yield return new WaitForSeconds(1f);
    isBlinking = false;
  }

  public void BlinkGood() {
    StartCoroutine(BT());
    StartCoroutine(BG());
  }

  public void BlinkBad() {
    StartCoroutine(BT());
    StartCoroutine(BB());
  }
}
