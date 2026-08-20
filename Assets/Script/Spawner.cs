using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] float spawnRate = 1.0f;
    private float timer = 0;
    private BaseControl baseControl;

    void Start()
    {
        SpawnEnemys();
        baseControl = GameObject.Find("Base").GetComponent<BaseControl>();

    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (baseControl.HP > 0)
            {
                SpawnEnemys();

            }

            timer = 0;
        }
    }

    void SpawnEnemys()
    {
         Instantiate(enemy, transform.position, transform.rotation);
    }
}
