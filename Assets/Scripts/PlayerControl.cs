using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControl : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private Vector3 rotation;

    [Header("Scale")]
    [SerializeField] private float scaleVar;
    private float direction;
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        transform.Rotate(rotation * -direction);
    }

    public void ChangeScale(bool Match)
    {
        if (transform.localScale == new Vector3(5, 5, 0) && Match)
        {
            return;
        }
        else if (transform.localScale == new Vector3(1, 1, 0) && !Match)
        {
            return;
        }

        float scaleMod = scaleVar;
        if (!Match)
        {
            scaleMod *= -1;
        }
        transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(transform.localScale.x + scaleMod, transform.localScale.y + scaleMod), 1);
    }
}
