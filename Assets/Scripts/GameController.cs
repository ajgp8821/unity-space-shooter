using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWailt;
    public float spawnWait;
    public float waveWait;

    private int score;
    public Text scoreText;

    public Text restartText;
    private bool restart;
    public Text gameOverText;
    private bool gameOver;

    private void Start() {
        restartText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update() {
        if (restart && Input.GetKeyDown(KeyCode.R)) {
            /*SceneManager.LoadScene(0);
            SceneManager.LoadScene("Main");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);*/
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWailt);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver) {
                restartText.gameObject.SetActive(true);
                restart = true;
                break;
            }
        }
    }

    private void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int value) {
        score += value;
        UpdateScore();
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
    }

}
