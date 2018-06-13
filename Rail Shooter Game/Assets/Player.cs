using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 6f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 6f;
    [Tooltip("In ms^-1")] [SerializeField] float xRange = 4f;
    [Tooltip("In ms^-1")] [SerializeField] float yRange = 2f;

    [SerializeField] float positionPitchFactor = -7f;
    [SerializeField] float positionYawFactor = 7f;

    float xThrow, yThrow;

    bool controlsEnabled = true;

    // Use this for initialization
    void Start () {
		
	}


    // Update is called once per frame
    void Update () {
        if (controlsEnabled) {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    void CharacterDeath() {
        //controlsEnabled = false;
        print("Character has died");
    }

    private void ProcessRotation() {
        float pitch = transform.localPosition.y * positionPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    private void ProcessTranslation() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float newX = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(newX, -xRange, xRange);
        transform.localPosition = new Vector3(clampedX, transform.localPosition.y, transform.localPosition.z);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float newY = transform.localPosition.y + yOffset;
        float clampedY = Mathf.Clamp(newY, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedY, transform.localPosition.z);
    }
}
