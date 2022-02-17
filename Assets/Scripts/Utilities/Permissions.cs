using UnityEngine;
using UnityEngine.Android;
using TMPro;

public class Permissions : MonoBehaviour
{
    public TextMeshProUGUI logs;
    [SerializeField] bool debug;
    void Start()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            // The user authorized use of the microphone.
           if(debug) logs.text = "has authorized";
        }
        else
        {
            // We do not have permission to use the microphone.
            // Ask for permission or proceed without the functionality enabled.
            if(debug) logs.text = "has not authorized";
            Permission.RequestUserPermission(Permission.Microphone);

        }
    }
}