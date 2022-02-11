using UnityEngine;

public class TwoDGyroController : MonoBehaviour
{
    public GameObject character;
    public float speed;
    public float sensitivity;

    private Gyroscope gyroScope;

    public float rotationAroundX;
    public float rotationAroundY;

    public bool EnableMoveY;
    public bool EnableMoveY_UsingRotationRate;

    bool isEnabled;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        if (SystemInfo.supportsGyroscope)
        {
            Debug.Log("Gyro is available");
            gyroScope = Input.gyro;
            gyroScope.enabled = true;
            isEnabled = true;
        }
        else
        {
            Debug.Log("Gyro is not available");
            isEnabled = false;
        }
    }

    void Update()
    {
        if (!isEnabled) return;
        if (character == null) return;
        if (EnableMoveY) MoveY();
        if (EnableMoveY_UsingRotationRate) MoveXY_UsingRotationRate();
    }

    void MoveY()
    {
        Vector3 rawGyroRotation = gyroScope.attitude.eulerAngles;
        Vector3 gyroRotation = new Vector3(-rawGyroRotation.x, rawGyroRotation.z, rawGyroRotation.y);
        
        //Debug.Log("rotation: " + gyroRotation);

        if (gyroRotation.x > -90)
        {
            Debug.Log("positive");
            character.transform.Translate(0, gyroRotation.x * speed, 0, Space.World);
        }
        else if (gyroRotation.x < -270)
        {
            Debug.Log("negative");
            float z = 90 + (gyroRotation.x + 270);
            character.transform.Translate(0, z * speed, 0, Space.World);
        }
    }

    void MoveXY_UsingRotationRate()
    {
        // In Update, accumulate rotational change in these axes:
        rotationAroundX += gyroScope.rotationRateUnbiased.x * Time.deltaTime;
        rotationAroundY += gyroScope.rotationRateUnbiased.y * Time.deltaTime;

        if (gyroScope.attitude.x > -sensitivity && gyroScope.attitude.x < sensitivity)
        {
            rotationAroundX = 0;
        }

        if (gyroScope.attitude.y > -sensitivity && gyroScope.attitude.y < sensitivity)
        {
            rotationAroundY = 0;
        }

        character.transform.Translate(new Vector3(rotationAroundY,  -rotationAroundX, 0).normalized*speed);
    }

    private void OnDrawGizmos()
    {
        if (gyroScope == null) return; 
        //Gizmos.DrawWireSphere(character.transform.position, speed);
        var gyro = new Vector3(gyroScope.rotationRateUnbiased.y, gyroScope.rotationRateUnbiased.x, gyroScope.rotationRateUnbiased.z);
        //Gizmos.DrawRay(character.transform.position, gyro * 10.0f);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(character.transform.position, new Vector3(rotationAroundY, -rotationAroundX, character.transform.position.z) * 10.0f);
    }
}
