using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour {

    [Tooltip("In meters per second")] [SerializeField] float xSpeed = 4f;
    [Tooltip("In meters per second")] [SerializeField] float ySpeed = 4f;

    [Tooltip("In meters")][Range(0f,100f)][SerializeField] float xRange = 33f;
    [Tooltip("In meters")] [Range(0f,100f)][SerializeField] float yRange = 20f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xRawNewPos = transform.localPosition.x + xOffset;
        float xFixNewPos = Mathf.Clamp(xRawNewPos, -xRange, xRange);

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float yRawNewPos = transform.localPosition.y + yOffset;
        float yFixNewPos = Mathf.Clamp(yRawNewPos, -yRange, yRange);

        transform.localPosition = new Vector3(xFixNewPos, yFixNewPos, transform.localPosition.z);

        bool fire1Down = CrossPlatformInputManager.GetButton("Fire1");
        bool fire2Down = CrossPlatformInputManager.GetButton("Fire2");
        bool fire3Down = CrossPlatformInputManager.GetButton("Fire3");


    }
}
