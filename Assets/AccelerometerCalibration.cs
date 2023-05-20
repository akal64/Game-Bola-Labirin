using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerCalibration : MonoBehaviour
{
    private Vector3 accelerometerOffset;

    private void Start()
    {
        CalibrateAccelerometer();
    }

    private void CalibrateAccelerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotationSnapshot = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), accelerationSnapshot);
        accelerometerOffset = rotationSnapshot * new Vector3(0f, 0f, -1f);
    }

    public Vector3 GetCalibratedAcceleration()
    {
        return Quaternion.Inverse(Quaternion.identity) * (Input.acceleration - accelerometerOffset);
    }

}
