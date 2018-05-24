using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour {

    [Header("Player Speed")]
    [Tooltip("In meters per second")] [SerializeField] float xSpeed = 20f;
    [Tooltip("In meters per second")] [SerializeField] float ySpeed = 20f;
    [SerializeField] GameObject[] guns;

    [Header("Movement Constraints")]
    [Tooltip("In meters")][SerializeField] float xRange = 11.03f;
    [Tooltip("In meters")][SerializeField] float yRange = 7f;

    [Header("Screen-Position Properties")]
    [SerializeField] float positionPitchFactor = 0.5f;
    [SerializeField] float positionYawFactor = 4.5f;

    [Header("Control Properties")]
    [SerializeField] float controlPitchFactor = 30f;
    [SerializeField] float controlRollFactor = 30f;

    private float xThrow, yThrow;
    private bool isControlDisabled = false;

	// Update is called once per frame
	void Update () {
        if (!isControlDisabled) {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessRotation() {
        float pitchFromPosition = positionPitchFactor * transform.localPosition.y;
        float pitchFromControl = yThrow * controlPitchFactor;
        float pitch = pitchFromPosition + pitchFromControl;

        float yaw = positionYawFactor * transform.localPosition.x + 180;

        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring() {
        bool fire1Down = CrossPlatformInputManager.GetButton("Fire1");
        bool fire2Down = CrossPlatformInputManager.GetButton("Fire2");
        bool fire3Down = CrossPlatformInputManager.GetButton("Fire3");

        SetActiveGuns(fire1Down);
    }

    private void SetActiveGuns(bool fireDown) {
        foreach (GameObject gObject in guns) {
            ParticleSystem.EmissionModule gunParticleSystem = gObject.GetComponent<ParticleSystem>().emission;
            gunParticleSystem.enabled = fireDown;
        }
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

    // Called from CollisionHandler.cs as String
    private void OnPlayerDeath() { 
        isControlDisabled = true;
    }
}
