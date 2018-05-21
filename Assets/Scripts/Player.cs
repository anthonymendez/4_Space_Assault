using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour {

    [Tooltip("In meters per second")] [SerializeField] float xSpeed = 20f;
    [Tooltip("In meters per second")] [SerializeField] float ySpeed = 20f;

    [Tooltip("In meters")][SerializeField] float xRange = 12.5f;
    [Tooltip("In meters")][SerializeField] float yRange = 7.79f;

    [SerializeField] float positionPitchFactor = 0.5f;
    [SerializeField] float controlPitchFactor = 30f;
    [SerializeField] float positionYawFactor = 0.5f;
    [SerializeField] float controlRollFactor = 30f;

    private float xThrow, yThrow;

    // Use this for initialization
    void Start () {
		
	}

    void OnCollisionEnter(Collision other) {
        print("Player hit something");
    }

    void OnTriggerEnter(Collider other) {
        print("Player hit trigger");
    }
	
	// Update is called once per frame
	void Update () {
        ProcessTranslation();
        ProcessRotation();
        RespondToFiring();
    }

    private void ProcessRotation() {
        float pitchFromPosition = positionPitchFactor * transform.localPosition.y;
        float pitchFromControl = yThrow * controlPitchFactor;
        float pitch = pitchFromPosition + pitchFromControl;

        float yaw = positionYawFactor * transform.localPosition.x + 180;

        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void RespondToFiring() {
        bool fire1Down = CrossPlatformInputManager.GetButton("Fire1");
        bool fire2Down = CrossPlatformInputManager.GetButton("Fire2");
        bool fire3Down = CrossPlatformInputManager.GetButton("Fire3");

    }

    private void ProcessTranslation() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xRawNewPos = transform.localPosition.x + xOffset;
        float xFixNewPos = Mathf.Clamp(xRawNewPos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float yRawNewPos = transform.localPosition.y + yOffset;
        float yFixNewPos = Mathf.Clamp(yRawNewPos, -yRange, yRange);

        transform.localPosition = new Vector3(xFixNewPos, yFixNewPos, transform.localPosition.z);
    }
}
