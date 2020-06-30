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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MotionControl("Horizontal", xSpeed, xRange);
        MotionControl("Vertical", ySpeed, yRange);
    }

    private void MotionControl(string direction, float speed, float dispRange)
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
