using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEffectsVolume : MonoBehaviour
{
    public MainMenu mainMenu;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.SetValueWithoutNotify(mainMenu.GetEffectsVolume()); ;
    }
}
