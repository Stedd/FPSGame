using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;

    private void Awake()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    private void AttackHitEvent()
    {
        if (target == null) return;
        if(target.GetComponent<IDamageable>() != null)
        {
            Debug.Log($"{transform.name} Hits {target.transform.name}");
            target.GetComponent<IDamageable>().ModifyHealth(-damage);
        }
    }

}
