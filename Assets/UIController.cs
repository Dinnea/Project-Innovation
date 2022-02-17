using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject debugUI;
    [SerializeField] bool debug = false;

    private void Start()
    {
        if (!debug) debugUI.SetActive(false);
    }
}
