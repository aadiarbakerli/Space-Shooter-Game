using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //public variables
    public GameObject[] dangers;
    public Vector3 startValues;
    public int dangerCount;
    public float waveTimer;
    public float startTime;
    public float restTimer;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    //private variables
    private int score;
    private bool gameOver;
    private bool restart;

    private void Start()
    {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        score = 0;
        TrackScore();
        StartCoroutine(SpawnWaves());
    }

    public void GameOver() {
        gameOverText.text = "Game Over.";
        gameOver = true;
    }

    private void Update()
    {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startTime);
        while (true) {
            for (int i = 0; i < dangerCount; i++) {
                GameObject danger = dangers[Random.Range(0, dangers.Length)];
                Vector3 startPosition = new Vector3(Random.Range(-startValues.x, startValues.x), startValues.y, startValues.z);
                Quaternion startRotation = Quaternion.identity;
                Instantiate(danger, startPosition, startRotation);
                yield return new WaitForSeconds(waveTimer);
            }
            yield return new WaitForSeconds(restTimer);
            if (gameOver) {
                restartText.text = "Press 'R' to start again!";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScore) {
        score += newScore;
        TrackScore();
    }

    void TrackScore() {
        scoreText.text = "Score: " + score;
    }
}
