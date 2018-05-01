using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandling : MonoBehaviour {

    //public variables
    public GameObject explosion;
    public GameObject playerCollision;
    public int scoreValue;

    //private variables
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        if (gameControllerObj != null) {
            gameController = gameControllerObj.GetComponent<GameController>();
        }
        if (gameController == null) {
            Debug.Log("GameController null");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Boundary") || other.tag == "Invader")
        {
            return;
        }
        if (explosion != null) {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player") {
            Instantiate(playerCollision, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.AddScore(scoreValue);
    }
}
