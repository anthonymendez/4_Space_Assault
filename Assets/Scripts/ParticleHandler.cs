using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour {

    [Tooltip("FX Prefab On Player")][SerializeField] GameObject deathFX;

    // Called from CollisionHandler.cs as String
    private void OnPlayerDeath() {
        deathFX.SetActive(true);
    }
}
