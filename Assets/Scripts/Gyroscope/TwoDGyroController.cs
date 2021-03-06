using UnityEngine;

public class TwoDGyroController : MonoBehaviour
{
    public GameObject character;
    [SerializeField] Bounce bounce;

    [Header("Variables")]
    public AnimationCurve curve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
    public float speedX;
    public float speedY;
    public float almostZero;
    [SerializeField] float upperClamp = 0.15f;
    public float arrowScale;

    [HideInInspector]
    public float rotationAroundX;
    [HideInInspector]
    public float rotationAroundY;

    private Gyroscope gyroScope;
    private Quaternion defaultRotation;
    private bool isEnabled;
    private Animator animator;

    public GameObject arrow;

    public bool isMoving = true;

    float t = 0.0f;
    float animLength;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        if (SystemInfo.supportsGyroscope)
        {
            //Debug.Log("Gyro is available");
            gyroScope = Input.gyro;
            gyroScope.enabled = true;
            isEnabled = true;
            SaveDefaultRotation();
        }
        else
        {
            //Debug.Log("Gyro is not available");
            isEnabled = false;
        }

        animator = character.GetComponentInChildren<Animator>();
        animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        //Debug.Log("AnimLength: " + animLength);
    }

    void Update()
    {
        if (!isEnabled) return;

        checkBoundaries();

        UpdateRotations();
        ResetXYRotations();
    }

    private void FixedUpdate()
    {
        if (!isEnabled) return;

        if (character != null)
        {
            if (isMoving)
            {
                if (!bounce.GetIsGrounded())
                {
                    MoveXY_UsingRotationRate();
                }
            }
        }
    }

    void MoveXY_UsingRotationRate()
    {

        t += Time.deltaTime;
        float scaledRotation = Mathf.Clamp(-rotationAroundX / upperClamp, 0, 1);

        //y speed depends on curve (see inspector), the curve repeats every animation loop.
        //max y speed depends on the current rotation.
        float moveY = Mathf.Lerp(0, scaledRotation * speedY, curve.Evaluate(t / animLength));
        float moveX = rotationAroundY * speedX;

        Vector3 moveVector = new Vector3(moveX, moveY);

        //make sure vector doesn't get bigger than y movement vector
        if (moveVector.magnitude > moveVector.y && moveVector.y > Mathf.Abs(moveVector.x))
        {
            moveVector = moveVector.normalized * moveVector.y;
        }

        //move character
        character.transform.Translate(moveVector);

        Vector2 f = new Vector2(scaledRotation, rotationAroundY);
        arrow.transform.localScale = new Vector3(arrow.transform.localScale.y, f.magnitude * arrowScale, 1);
        arrow.transform.rotation = Quaternion.Euler(arrow.transform.rotation.eulerAngles.x, arrow.transform.rotation.eulerAngles.y, -Vector2.SignedAngle(new Vector2(1, 0), f) * 2);
    }

    private void UpdateRotations()
    {
        //Accumulate rotational change in these axes:
        rotationAroundX += gyroScope.rotationRateUnbiased.x * Time.deltaTime;
        rotationAroundY += gyroScope.rotationRateUnbiased.y * Time.deltaTime;
    }

    private void ResetXYRotations()
    {
        if (gyroScope.attitude.x > -almostZero + defaultRotation.x && gyroScope.attitude.x < almostZero + defaultRotation.x)
        {
            rotationAroundX = 0;
        }

        if (gyroScope.attitude.y > -almostZero + defaultRotation.y && gyroScope.attitude.y < almostZero + defaultRotation.y)
        {
            rotationAroundY = 0;
        }
    }

    private void checkBoundaries()
    {
        character.transform.position = new Vector3(Mathf.Clamp(character.transform.position.x, -6.5f, 6.5f), character.transform.position.y);
    }

    public void SaveDefaultRotation()
    {
        if (defaultRotation != null)
        {
            Debug.Log("DefaultRotation: " + defaultRotation);
        }
        defaultRotation = gyroScope.attitude;
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
