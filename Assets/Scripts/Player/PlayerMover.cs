using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    #region Relations
    [SerializeField] private GameObject player;
    #endregion

    #region Modifiable parameters
    [SerializeField]
    private bool mobileInput;
    [SerializeField] private float speed;
    [SerializeField] private float inputSensitivity;
    [Tooltip("How far from center player can move to left and right directions")]
    [SerializeField] private float xClamp;
    [Tooltip("How far from center player can move forward")]
    [SerializeField] private float forwardClamp;
    [Tooltip("How far from center player can move backward")]
    [SerializeField] private float backwardClamp;
    #endregion

    #region InnerParameters
    bool moveForward;
    bool activeInput;
    float xDelta;
    float zDelta;
    Vector3 playerInput;
    Vector3 playerLocalPos;
    float initialSpeed;
    bool alive = true;

    #endregion

    private void Start()
    {
        initialSpeed = speed;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) if (alive) StartMovement();
        if(moveForward) transform.position += Vector3.forward * speed / 10;
        if(activeInput)
        {
            if (mobileInput)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        xDelta = touch.deltaPosition.x;
                        zDelta = touch.deltaPosition.y;
                    }
                }
                if(Input.touchCount == 0)
                {
                    xDelta = zDelta = 0;
                }
            }
            else
            {
                xDelta = Input.GetAxis("Mouse X");
                zDelta = Input.GetAxis("Mouse Y");
            }

            playerInput = new Vector3(xDelta, 0, zDelta);
            playerLocalPos = player.transform.localPosition;
            playerLocalPos = Vector3.Lerp(playerLocalPos, playerLocalPos + playerInput, Time.deltaTime * inputSensitivity);
            ClampLocalTransform();
            player.transform.localPosition = playerLocalPos;
        }
    }

    private void ClampLocalTransform()
    {
        playerLocalPos.x = Mathf.Clamp(playerLocalPos.x, -xClamp, xClamp);
        playerLocalPos.z = Mathf.Clamp(playerLocalPos.z, -backwardClamp, forwardClamp);
    }

    public void StartMovement()
    {
            moveForward = true;
            activeInput = true;
    }

    public void StopMovement()
    {
        moveForward = false;
        activeInput = false;
        alive = false;
    }

    public void StopInput()
    {
        activeInput = false;
        alive = false;
    }

    public void Boost(float amount)
    {
        speed *= amount;
    }

    public void ResetSpeed()
    {
        speed = initialSpeed;
    }

    public void ResetPlayer()
    {
        alive = true;
        transform.position = Vector3.zero;
        playerLocalPos.x = 0;
        playerLocalPos.z = 0;
        player.transform.localPosition = playerLocalPos;
    }
}
