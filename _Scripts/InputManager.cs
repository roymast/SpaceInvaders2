using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerMovment playerMovment;
    [SerializeField] Shooter shooter;    

    bool isGameRunning;
    bool isLastMovementFromUIButton;

    Camera mainCam;
    VibrateManager vibrateManager;
    private void Start()
    {
        isLastMovementFromUIButton = false;
        mainCam = Camera.main;
        vibrateManager = VibrateManager.Instance;
        GameManager.Instance.OnGameStart    += () => isGameRunning = true;
        GameManager.Instance.OnGameOver     += () => isGameRunning = false;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnGameStart -= () => isGameRunning = true;
        GameManager.Instance.OnGameOver -= () => isGameRunning = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                MoveLeft();
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                MoveRight();
            else
                StopMoving();                

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                Shoot();
        }
        else
            playerMovment.HorizontalMovement = 0;
    }
    public void MoveLeft(bool isFromUIButton = false)
    {
        isLastMovementFromUIButton = isFromUIButton;
        if (mainCam.WorldToViewportPoint(transform.position).x <= 0.1f)
        {
            playerMovment.HorizontalMovement = 0;
            return;
        }
        if (isGameRunning)
            playerMovment.HorizontalMovement = -1;
        else
            playerMovment.HorizontalMovement = 0;
    }
    public void MoveRight(bool isFromUIButton = false)
    {
        isLastMovementFromUIButton = isFromUIButton;
        if (mainCam.WorldToViewportPoint(transform.position).x >= 0.9f)
        {
            playerMovment.HorizontalMovement = 0;
            return;
        }
        if (isGameRunning)
            playerMovment.HorizontalMovement = 1;
        else
            playerMovment.HorizontalMovement = 0;
    }
    public void StopMoving(bool isFromUIButton = false)
    {
        if(isFromUIButton)
            playerMovment.HorizontalMovement = 0;
        if (!isLastMovementFromUIButton)
            playerMovment.HorizontalMovement = 0;
    }
    public void Shoot()
    {
        if (isGameRunning)
        {
            vibrateManager.Vibrate();
            shooter.Shoot();
        }
    }
}
