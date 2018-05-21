using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

    [Tooltip("In Seconds")][SerializeField] float timeToSelfDestruct = 1f;

	// Use this for initialization
	void Start () {
        SelfDestruct();
	}

    private void SelfDestruct() {
        Destroy(gameObject, timeToSelfDestruct);
    }
}
