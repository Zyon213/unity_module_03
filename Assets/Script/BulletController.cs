using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 targetDirection;
    private EnemyController enemyController;
    public float damage = 0.2f;

    public void SetTarget(Vector2 targetPosition)
    {
        targetDirection = (targetPosition - (Vector2)transform.position).normalized;
    }

    void Update()
    {
        transform.Translate(targetDirection * speed * Time.deltaTime);

        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                enemyController.HP -= damage;

                if (enemyController.HP <= 0)
                {
                    Destroy(other.gameObject); 
                }
            }

            Destroy(gameObject);
        }
    }
}
