using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireDistance = 3.0f;  
    public float fireRate = 0.5f;      
    private float nextFireTime = 0f;


    void Update()
    {
        Transform target = GetClosestEnemy();

        if (target != null)
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance <= fireDistance && Time.time >= nextFireTime)
            {
                ShootBullet(target);
                nextFireTime = Time.time + fireRate; 
            }
        }
    }

    Transform GetClosestEnemy()
    {
        EnemyController[] enemies = GameObject.FindObjectsOfType<EnemyController>();
        Transform closest = null;
        float minDistance = Mathf.Infinity;

        foreach (EnemyController enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy.transform;
            }
        }

        return closest;
    }

    void ShootBullet(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetTarget(target.position);
    }
}
