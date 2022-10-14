using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _damage = 40f;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerHealth>().transform;
    }

    private void AttackHitEvent()
    {
        if (_target == null) return;
        if (_target.GetComponent<IDamageable>() != null) return;
        Debug.Log($"{transform.name} Hits {_target.transform.name}");
        _target.GetComponent<IDamageable>().ModifyHealth(-_damage);
    }
}