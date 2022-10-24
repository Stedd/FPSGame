using UnityEngine;

[CreateAssetMenu(menuName = "FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float _value;

    public float Value
    {
        get => _value;
        set => this._value = value;
    }
}