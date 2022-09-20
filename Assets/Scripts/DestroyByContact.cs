using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    private void Start() {
        // gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else {
            Debug.LogWarning("There is no object with the tag \"GameController\"");
        }

    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("Name " + other.name);
        // if (other.tag == "Boundary") return;
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) return;

        if (explosion != null) {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        
        if (other.CompareTag("Player")) {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        
        if (gameController) {
            gameController.AddScore(scoreValue);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
