using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWailt;
    public float spawnWait;
    public float waveWait;

    private int score;
    public Text scoreText;

    public GameObject restartGameObject;
    private bool restart;
    public GameObject gameOverGameObject;
    private bool gameOver;

    private void Start() {
        restartGameObject.SetActive(false);
        gameOverGameObject.SetActive(false);

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update() {
        if (restart && Input.GetKeyDown(KeyCode.R)) {
            Restart();
        }
    }

    public void Restart() {
        /*SceneManager.LoadScene(0);
        SceneManager.LoadScene("Main");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWailt);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector2 half = Utils.GetDimensionsInWorldUnits() / 2;
                // Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Vector3 spawnPosition = new Vector3(Random.Range(-half.x + 1.17f, half.x - 1.17f), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver) {
                restartGameObject.SetActive(true);
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
        gameOverGameObject.SetActive(true);
        gameOver = true;
    }

}
