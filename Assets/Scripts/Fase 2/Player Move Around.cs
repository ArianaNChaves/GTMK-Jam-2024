using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAround : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform enemyPosition;
    
    void Update()
    {
        MoveAround();
    }

    private void MoveAround()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(enemyPosition.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(enemyPosition.position, Vector3.forward, -rotationSpeed * Time.deltaTime);

        }
    }
}
