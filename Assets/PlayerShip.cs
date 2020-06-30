using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour
{
    [Tooltip("m/s")][SerializeField] float xSpeed = 5f;
    [Tooltip("m")][SerializeField] float xRange = 7f;
    [Tooltip("m/s")][SerializeField] float ySpeed = 5f;
    [Tooltip("m")][SerializeField] float yRange = 7f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -5f;

    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessingTranslation("Horizontal", xSpeed, xRange);
        ProcessingTranslation("Vertical", ySpeed, yRange);
        ProcessRotation();
        
    }

    private void ProcessRotation()
    {
        float pitch = calcPitch();
        float yaw = 0f;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private float calcPitch()
    {
        float pitchFromCurrentPosition = transform.localPosition.y * positionPitchFactor;
        float pitchFromControl = CrossPlatformInputManager.GetAxis("Vertical") * controlPitchFactor;
        return pitchFromCurrentPosition + pitchFromControl;
    }

    private void ProcessingTranslation(string direction, float speed, float dispRange)
    {
        float keyThrow = CrossPlatformInputManager.GetAxis(direction);
        float offset = keyThrow * speed * Time.deltaTime; //offset at a frame

        Vector3 tempPos = transform.localPosition;

        if (direction == "Horizontal") 
        {
            tempPos.x = Mathf.Clamp((tempPos.x += offset), -dispRange, dispRange);
        }
        else if (direction == "Vertical")
        {
            tempPos.y = Mathf.Clamp((tempPos.y += offset), -dispRange, dispRange);
        }

        transform.localPosition = new Vector3(tempPos.x,tempPos.y,tempPos.z);        
    }

}
