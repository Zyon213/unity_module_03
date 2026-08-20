using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private float lowerBound = -4.0f;
    private BaseControl baseControl;
    public float HP = 3.0f;
    void Start()
    {
        baseControl = GameObject.Find("Base").GetComponent<BaseControl>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime, Space.World);
        if (transform.position.y < lowerBound || baseControl.HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
