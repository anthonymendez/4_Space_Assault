using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour { 

    [Tooltip("In Seconds")][SerializeField] float loadSceneDelay = 1f;

    void OnCollisionEnter(Collision other) {
        print("Player hit something");
    }

    void OnTriggerEnter(Collider other) {
        StartDeathSequence();
    }

    private void StartDeathSequence() {
        gameObject.SendMessage("OnPlayerDeath");
        Invoke("ReloadScene", loadSceneDelay);
    }

    private void ReloadScene() { // Reference as String
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
