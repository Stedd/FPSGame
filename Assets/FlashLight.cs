using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float _powerDraw;
    [SerializeField] private float _maxCharge;
    [SerializeField] private float _range;
    [SerializeField] private float _angle;
    [SerializeField] private float _intensity;

    [Header("State")]
    [SerializeField] private bool _isActive;
    [field: SerializeField] public float CurrentCharge { get; private set; }
    [field: SerializeField] private FloatVariable _S_currentCharge;

    [Header("Connection")]
    [SerializeField] private Light _light;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void OnEnable()
    {
        CurrentCharge = _maxCharge;
        _light.enabled = false;
    }

    private void Update()
    {
        ToggleFlashlight();

        if (_isActive)
        {
            CurrentCharge -= _powerDraw * Time.deltaTime;
            CurrentCharge = Mathf.Clamp(CurrentCharge, 0, _maxCharge);
            if (CurrentCharge >= 0)
            {
                FlashLightOff();
            }
        }

        UpdateUI();
    }

    private void FlashLightOff()
    {
        _light.enabled = false;
        _isActive = false;
    }

    private void FlashLightOn()
    {
        _light.enabled = true;
    }

    private void ToggleFlashlight()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            _isActive = !_isActive;

            if (_isActive)
            {
                FlashLightOn();
            }
            else
            {
                FlashLightOff();
            }
        }
    }

    public void ModifyCharge(float modifyValue)
    {
        CurrentCharge += modifyValue;
        CurrentCharge = Mathf.Clamp(CurrentCharge, 0, _maxCharge);
    }

    public float GetChargeFactor()
    {
        return CurrentCharge / _maxCharge;
    }

    private void UpdateUI()
    {
        _S_currentCharge.Value = GetChargeFactor() * 100f;
    }
}