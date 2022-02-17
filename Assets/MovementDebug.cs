using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDebug : MonoBehaviour
{
    [SerializeField] MovementPC movementPC;
    [SerializeField] TwoDGyroController gyroController;

    public void EnableMove(bool value)
    {
        movementPC.enabled = value;
        gyroController.enabled = value;
    }
}
