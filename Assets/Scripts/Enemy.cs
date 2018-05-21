using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private MeshCollider meshCollider;

    void Start() {
        AddNonTriggerMeshCollider();
    }

    private void AddNonTriggerMeshCollider() {
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other) {
        Destroy(gameObject);
    }

}
