using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public float scrollSpeed = -1.0f;
    public static GameController instance;
    public bool gameOver = false;
    public int lives = 7;
    public int score;

	// Use this for initialization
	void Awake () {
    if (instance == null) instance = this;
    else if (instance != this) Destroy(gameObject);
  }

	void Start(){
		MusicPlayer.instance.StartMusic(true);
	}
	
	void Update () {
    if (lives <= 0) {
      gameOver = true;
      //ya dun man
      StartCoroutine(RestartOnSpacePress());
    }
	}

  IEnumerator RestartOnSpacePress(){
    while (true) {
      if (Input.GetKeyDown(KeyCode.R))
          //1 is the main scene
          SceneManager.LoadScene(1, LoadSceneMode.Single);
      else if (Input.GetKeyDown(KeyCode.Escape)) {
          MusicPlayer.instance.StartMusic(false);
          SceneManager.LoadScene(0);
      }
      yield return new WaitForEndOfFrame();
    }
  }
}
