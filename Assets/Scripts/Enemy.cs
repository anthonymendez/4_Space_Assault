using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] Transform parent;
    [SerializeField] GameObject deathFX;

    private MeshCollider meshCollider;

    void Start() {
        AddNonTriggerMeshCollider();
    }

    private void AddNonTriggerMeshCollider() {
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other) {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

}
