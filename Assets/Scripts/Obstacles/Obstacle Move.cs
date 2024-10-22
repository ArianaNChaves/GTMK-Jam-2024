using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed;

    private Vector3 _targetPosition;
    private bool _isMovingToPointB = true;
    private const float ProximityThreshold = 0.1f;

    private Animator anim;

    void Start()
    {
        _targetPosition = pointB.position;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPosition, speed * Time.deltaTime);

        if (IsCloseEnoughToTarget())
        {
            ChangeDirection();
        }
    }
    private bool IsCloseEnoughToTarget()
    {
        return Vector3.Distance(transform.position, _targetPosition) < ProximityThreshold;
    }

    private void ChangeDirection()
    {
        anim.SetTrigger("ChangeHand");
        _isMovingToPointB = !_isMovingToPointB;
        _targetPosition = _isMovingToPointB ? pointB.position : center.position;
    }
    
}
