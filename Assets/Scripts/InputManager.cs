using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private string _horizontalAxis;
    private string _verticalAxis;

    public string HorizontalAxis { get => _horizontalAxis; }
    public string VerticalAxis { get => _verticalAxis; }

    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.French)
        {
            _horizontalAxis = "HorizontalAzerty";
            _verticalAxis = "VerticalAzerty";
        }
        else
        {
            _horizontalAxis = "Horizontal";
            _verticalAxis = "Vertical";
        }
    }
}
