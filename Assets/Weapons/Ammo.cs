using UnityEngine;

public class Ammo : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private int _maxMagAmmoAmount;

    [Header("State")]
    [SerializeField] private int _currentMagAmmoAmount;

    [Header("Connections")]
    [SerializeField] private AmmoBelt _ammoBelt;
    [SerializeField] private FloatVariable _S_currentBeltAmmoAmount;
    [SerializeField] private FloatVariable _S_currentMagAmmoAmount;

    private void Awake()
    {
        _ammoBelt = GetComponentInParent<AmmoBelt>();

        _currentMagAmmoAmount = _maxMagAmmoAmount;
    }

    private void OnEnable()
    {
        AmmoUpdate();
    }

    #region Public Properties

    public AmmoType AmmoType
    {
        get => _ammoType;
        set => _ammoType = value;
    }

    public int MaxMagAmmoAmount
    {
        get => _maxMagAmmoAmount;
        set => _maxMagAmmoAmount = value;
    }

    public int CurrentMagAmmoAmount
    {
        get => _currentMagAmmoAmount;
        set => _currentMagAmmoAmount = value;
    }

    #endregion

    #region Setters

    public void Reload()
    {
        int diff = _maxMagAmmoAmount - _currentMagAmmoAmount;
        print(diff);
        if (diff < _ammoBelt.GetBeltCurrentAmmoAmount(_ammoType))
        {
            _ammoBelt.ModifyBeltCurrentAmmoAmount(_ammoType, -diff);
            _currentMagAmmoAmount += diff;
        }
        else
        {
            _currentMagAmmoAmount += _ammoBelt.GetBeltCurrentAmmoAmount(_ammoType);
            _ammoBelt.SetBeltCurrentAmmoAmount(_ammoType, 0);
        }

        AmmoUpdate();
    }

    public void ModifyMagAmmo(int modifyValue)
    {
        _currentMagAmmoAmount += modifyValue;
        if (_currentMagAmmoAmount > _maxMagAmmoAmount)
        {
            _currentMagAmmoAmount = _maxMagAmmoAmount;
        }

        if (_currentMagAmmoAmount <= 0)
        {
            _currentMagAmmoAmount = 0;
        }

        AmmoUpdate();
    }

    #endregion

    #region Getters

    public float GetMagazineAmmoFactor()
    {
        return _currentMagAmmoAmount / (float)_maxMagAmmoAmount;
    }

    public float GetBeltAmmoFactor()
    {
        return _ammoBelt.GetBeltCurrentAmmoAmount(_ammoType) / (float)_ammoBelt.GetBeltMaxAmmoAmount(_ammoType);
    }

    #endregion

    private void AmmoUpdate()
    {
        _S_currentBeltAmmoAmount.Value = _ammoBelt.GetBeltCurrentAmmoAmount(_ammoType);
        _S_currentMagAmmoAmount.Value = _currentMagAmmoAmount;
    }
}