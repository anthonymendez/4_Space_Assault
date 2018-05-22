using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] Transform parent;
    [SerializeField] GameObject deathFX;

    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hitsToDeath = 10;

    ScoreBoard scoreBoard;

    private MeshCollider meshCollider;

    void Start() {
        AddNonTriggerMeshCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerMeshCollider() {
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (hitsToDeath <= 0) {
            KillEnemy();
        }
    }

    private void ProcessHit() {
        scoreBoard.ScorePerHit(scorePerHit);
        // todo add FX stuff
        hitsToDeath--;
    }

    private void KillEnemy() {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
