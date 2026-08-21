using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BaseControl : MonoBehaviour
{
    public int HP = 5;
    public int Energy = 5;

    [SerializeField] private GameObject[] turrets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( HP <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            --HP;
            Debug.Log("HP : " + HP);
        }

    }

    public void CheckBaseEnergy()
    {
        foreach (GameObject turret in turrets)
        {
            int price = turret.GetComponent<TurretManager>().price;
            Image turretImage = turret.GetComponent<Image>();
            Color turretColor = turretImage.color;
            if (Energy < price)
            {
                turretColor.a = 0.1f;
            }
            else
                turretColor.a = 1.0f;
                
        }
    }
}
