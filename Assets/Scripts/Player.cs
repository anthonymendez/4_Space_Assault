using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        bool fire1Down = CrossPlatformInputManager.GetButton("Fire1");
        bool fire2Down = CrossPlatformInputManager.GetButton("Fire2");
        bool fire3Down = CrossPlatformInputManager.GetButton("Fire3");

        gameObject.transform.Translate(Vector3.left * horizontalThrow);
        gameObject.transform.Translate(Vector3.up * verticalThrow);
    }
}
