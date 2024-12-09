using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    ThrowCube throwCube;
    PlayerCamera playerCamera;
    TargetStand targetStand;
    TMP_Text throwBtnText;

    [SerializeField] List<Transform> controllers;///controllers[0] joystick ///controllers[1] dpad ///controllers[2] btnThrow


    // Start is called before the first frame update
    void Start()
    {
        throwCube = FindFirstObjectByType<ThrowCube>();
        playerCamera = FindFirstObjectByType<PlayerCamera>();
        targetStand = FindFirstObjectByType<TargetStand>();
        throwBtnText = transform.GetChild(0).GetComponent<TMP_Text>();

    }

   

    public void ThrowPush()
    {
        Start();//re assign throwCube
        if (!throwCube.afterThrow)
        {
            throwCube.inCharge = true;

        }
        else if (throwBtnText.text.ToLower() is "next")
        {
            targetStand.changeTarget = true;
            throwCube.afterThrow = false;
        }

    }
    public void ThrowPop()
    {
        if (throwCube.inCharge)
        {
            throwCube.inCharge = false;
            throwCube.throwThat = true;
        }

    }

    /////// Player Camera
    public void CamRightPush()
    {
        playerCamera.turnRight = true;
    }
    public void CamRightPop()
    {
        playerCamera.turnRight = false;
    }
    public void CamLeftPush()
    {
        playerCamera.turnLeft = true;
    }
    public void CamLeftPop()
    {
        playerCamera.turnLeft = false;
    }
    public void CamTopPush()
    {
        playerCamera.turnTop = true;
    }
    public void CamTopPop()
    {
        playerCamera.turnTop = false;
    }
    public void CamDownPush()
    {
        playerCamera.turnDown = true;
    }
    public void CamDownPop()
    {
        playerCamera.turnDown = false;
    }

 
}
