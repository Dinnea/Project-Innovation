using UnityEngine;

public class TwoDGyroController : MonoBehaviour
{
    public GameObject character;
    public float speed;

    private Gyroscope gyroScope;

    public bool EnableMoveY;
    public bool MoveZCubeBool;
    public bool RotateCubeBool;

    bool isEnabled;

    void Start()
    {
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
        if (EnableMoveY) newMoveY(); //MoveY();
    }

    //TO DO:
    // add moveX
    // set angle at which character doesn't move

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

    void newMoveY()
    {
        Vector3 rawGyroRotation = gyroScope.attitude.eulerAngles;
        Quaternion gyroRotation = new Quaternion(0.0f, 0.5f, 0.5f, 0.0f) * gyroScope.attitude;
        
        Quaternion rotation = new Quaternion(-Input.gyro.attitude.x, 0, 0, Input.gyro.attitude.w);

        //Debug.Log("rotation: " + rotation);

        //character.transform.Translate(new Vector3(0, rotation.eulerAngles.x * speed, 0));

        //Debug.Log("Pitch: " + pitch);
        //Debug.Log("Roll: " + roll);
    }
    

    void MoveX()
    {
        Vector3 rawGyroRotation = gyroScope.attitude.eulerAngles;
        Vector3 gyroRotation = new Vector3(-rawGyroRotation.y, rawGyroRotation.y, rawGyroRotation.x);

        //Debug.Log("rotation: " + gyroRotation.x);

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
}
