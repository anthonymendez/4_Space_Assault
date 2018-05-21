using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour { 

    void OnCollisionEnter(Collision other) {
        print("Player hit something");
    }

    void OnTriggerEnter(Collider other) {
        StartDeathSequence();
    }

    private void StartDeathSequence() {
        gameObject.SendMessage("disableControls");
    }
}
