using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float _detectRange = 15f;
    [SerializeField] private float _attackRange = 5f;
    [SerializeField] private float _rotationSpeed = 0.1f;
    [Header("State")]
    [SerializeField] private Transform _target;
    [SerializeField] private bool _isProvoked;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private static readonly int MoveAnimation = Animator.StringToHash("Move");
    private static readonly int AttackAnimation = Animator.StringToHash("Attack");
    private static readonly int IdleAnimation = Animator.StringToHash("Idle");

    public bool IsProvoked
    {
        get => _isProvoked;
        set => _isProvoked = value;
    }

    private void Awake()
    {
        _target = FindObjectOfType<PlayerHealth>().transform;
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetStopDistance(_attackRange * 0.9f);

        if (DistanceToTarget(_target.position) < _detectRange)
        {
            _isProvoked = true;
        }

        if (_isProvoked)
        {
            EngageTarget();
        }
    }

    private void EngageTarget()
    {
        if (DistanceToTarget(_target.position) <= _attackRange)
        {
            AttackTarget();
        }
        else if (_isProvoked)
        {
            FollowTarget();
        }
        else
        {
            Idle();
        }
    }

    private void FollowTarget()
    {
        _animator.SetTrigger(MoveAnimation);
        _animator.SetBool(AttackAnimation, false);
        _navMeshAgent.SetDestination(_target.position);
    }

    private void AttackTarget()
    {
        _animator.SetBool(AttackAnimation, true);
        //print("Die Human!");
    }

    private void Idle()
    {
        _animator.SetTrigger(IdleAnimation);
    }

    private void SetStopDistance(float stopDistance)
    {
        _navMeshAgent.stoppingDistance = stopDistance;
    }

    private float DistanceToTarget(Vector3 targetPosition)
    {
        return Vector3.Distance(gameObject.transform.position, targetPosition);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectRange);
        if (_navMeshAgent != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _navMeshAgent.stoppingDistance);
        }
    }
}