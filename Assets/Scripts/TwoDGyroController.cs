using UnityEngine;

public class TwoDGyroController : MonoBehaviour
{
    public AnimationCurve curve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

    public GameObject character;
    [SerializeField] Bounce bounce;

    public float speedX;
    public float speedY;
    public float almostZero;
    [SerializeField] float upperClamp = 0.2f;
    public bool EnableMoveY_UsingRotationRate;

    //[HideInInspector]
    public float rotationAroundX;
    //[HideInInspector]
    public float rotationAroundY;

    private Gyroscope gyroScope;
    private Quaternion defaultRotation;
    private bool isEnabled;
    private Animator animator;

    float t = 0.0f;
    float animLength;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        if (SystemInfo.supportsGyroscope)
        {
            Debug.Log("Gyro is available");
            gyroScope = Input.gyro;
            gyroScope.enabled = true;
            isEnabled = true;
            SaveDefaultRotation();
        }
        else
        {
            Debug.Log("Gyro is not available");
            isEnabled = false;
        }

        animator = character.GetComponentInChildren<Animator>();
        animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        Debug.Log("AnimLength: " + animLength);
    }

    void Update()
    {
        if (!isEnabled) return;

        if (character != null)
        {
            if (!bounce.GetIsGrounded())
            {
                if (EnableMoveY_UsingRotationRate) MoveXY_UsingRotationRate();
            }
        }
    }

    void MoveXY_UsingRotationRate()
    {

        // In Update, accumulate rotational change in these axes:
        rotationAroundX += gyroScope.rotationRateUnbiased.x * Time.deltaTime;

        rotationAroundY += gyroScope.rotationRateUnbiased.y * Time.deltaTime;


        if (gyroScope.attitude.x > -almostZero + defaultRotation.x && gyroScope.attitude.x < almostZero + defaultRotation.x)
        {
            //Debug.Log("Reset X to zero");
            rotationAroundX = 0;
        }

        if (gyroScope.attitude.y > -almostZero + defaultRotation.y && gyroScope.attitude.y < almostZero + defaultRotation.y)
        {
            //Debug.Log("Reset Y to zero");
            rotationAroundY = 0;
        }

        float moveX = rotationAroundY;
        float scaledRotation = Mathf.Clamp(-rotationAroundX / upperClamp, 0, 1);

        t += Time.deltaTime;

        float moveY = Mathf.Lerp(0, scaledRotation * speedY, curve.Evaluate(t / animLength));

        Vector3 a = new Vector3(moveX * speedX, moveY);

        //make sure vector doesn't get bigger than y movement vector
        if (a.magnitude > a.y && a.y > Mathf.Abs(a.x))
        {
            a = a.normalized * a.y;
        }

        character.transform.Translate(a);

        //character.transform.Translate(new Vector3(moveX * speedX, Mathf.Clamp(moveY, 0, Mathf.Infinity) * speedY));


    }

    public void SaveDefaultRotation()
    {
        if (defaultRotation != null)
        {
            Debug.Log("DefaultRotation: " + defaultRotation);
        }
        defaultRotation = gyroScope.attitude;

        
        Debug.Log("NEW DefaultRotation: " + defaultRotation);
    }

    public void SetTAtZero()
    {
        t = 0;
    }

    private void OnDrawGizmos()
    {
        if (gyroScope == null || character == null) return;
        //Gizmos.DrawWireSphere(character.transform.position, speed);
        var gyro = new Vector3(gyroScope.rotationRateUnbiased.y, gyroScope.rotationRateUnbiased.x, gyroScope.rotationRateUnbiased.z);
        //Gizmos.DrawRay(character.transform.position, gyro * 10.0f);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(character.transform.position, new Vector3(rotationAroundY, -rotationAroundX, character.transform.position.z) * 10.0f);
    }
}
