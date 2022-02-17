using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDebug : MonoBehaviour
{
    [SerializeField] MovementPC movementPC;
    [SerializeField] TwoDGyroController gyroController;

    public void EnableMove(bool value)
    {
        if (movementPC!= null) movementPC.enabled = value;
        if(gyroController!=null) gyroController.isMoving= value;
    }
}
