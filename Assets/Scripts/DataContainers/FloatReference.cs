using System;
using UnityEngine;

/// <summary>
/// Data class to more fluently operate with float fields
/// </summary>

[Serializable]
public class FloatReference 
{
    [SerializeField] private bool _useConstant = true;
    [SerializeField] private float _constantValue;
    [SerializeField] private FloatVariableSO _variable;

    public float Value => _useConstant ? _constantValue : _variable.Value;

}
