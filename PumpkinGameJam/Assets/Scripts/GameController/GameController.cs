using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public float scrollSpeed = -1.0f;
    public bool gameOver = false;
    public int lives = 7;
    public int score;

    public string longestWord;
    public int wordCount;
  public bool paused;
    // Use this for initialization
	void Awake () {
    if (instance == null) instance = this;
    else if (instance != this) Destroy(gameObject);

    longestWord = "";
    wordCount = 0;
    }

	void Start(){
		MusicPlayer.instance.StartMusic(true);
    }
	
	void Update () {
    if (!gameOver && Input.GetKeyDown(KeyCode.P)) {
      if (!paused) {
        Time.timeScale = 0;
        paused = true;
      } else {
        paused = false;
        Time.timeScale = 1;
      }
    }
    if (!gameOver && paused && Input.GetKeyDown(KeyCode.Escape)) {
      SceneManager.LoadScene(0, LoadSceneMode.Single);
      paused = false;
      Time.timeScale = 1;
    }
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
