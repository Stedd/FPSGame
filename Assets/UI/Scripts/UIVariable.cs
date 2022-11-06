using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIVariable : MonoBehaviour
{
    [SerializeField] private string _prefix;
    [SerializeField] private FloatVariable _variable;
    [SerializeField] private TextMeshProUGUI _textObject;
    [SerializeField] private string _text;

    private void OnEnable()
    {
        _textObject = GetComponent<TextMeshProUGUI>();
        _text = _textObject.text;
    }

    private void Update()
    {
        _textObject.text = _prefix + _variable.Value;
    }
}