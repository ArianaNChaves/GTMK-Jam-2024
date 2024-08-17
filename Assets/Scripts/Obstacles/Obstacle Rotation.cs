using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed;

    private Vector3 _targetPosition;
    private bool _isMovingToPointB = true;
    private const float ProximityThreshold = 0.1f;

    void Start()
    {
        _targetPosition = pointB.position;
    }
    void Update()
    {
        LookAtCenter();
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
        _isMovingToPointB = !_isMovingToPointB;
        _targetPosition = _isMovingToPointB ? pointB.position : center.position;
    }
    private void LookAtCenter()
    {
        Vector3 direction = center.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
