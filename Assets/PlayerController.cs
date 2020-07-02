using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("m/s")][SerializeField] float xSpeed = 50f;
    [Tooltip("m")][SerializeField] float xRange = 14f;
    [Tooltip("m/s")][SerializeField] float ySpeed = 35f;
    [Tooltip("m")][SerializeField] float yRange = 8.5f;
    [Header("Position And Throw")]
    [SerializeField] float positionPitchFactor = -1.7f;
    [SerializeField] float controlPitchFactor = -13f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = 15f;

    bool isControlEnabled = true;

    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessingTranslation("Horizontal", xSpeed, xRange);
            ProcessingTranslation("Vertical", ySpeed, yRange);
            ProcessRotation();
        }        
    }

    private void ProcessRotation()
    {
        float pitch = CalcPitch();
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = CrossPlatformInputManager.GetAxis("Horizontal") * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private float CalcPitch()
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

    private void OnPlayerDeath() //called by string reference
    {
        isControlEnabled = false;
    }

}
