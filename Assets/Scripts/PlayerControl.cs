using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControl : MonoBehaviour
{
    [Header ("Rotation")]
    [SerializeField] private Vector3 rotation;

    [Header ("Scale")]
    [SerializeField] private float scaleVar;
    private float direction;
    void Start()
    {
        
    }


    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal")  * Time.deltaTime;

        transform.Rotate(rotation * -direction);
    }

    public void ChangeScale(bool Match){

        if (!Match)
        {
            scaleVar *= -1;
        }
        transform.localScale = new Vector2(transform.localScale. x + scaleVar, transform.localScale.y + scaleVar);
    }
}
