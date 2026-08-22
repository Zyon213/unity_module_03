using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BaseControl : MonoBehaviour
{
    public int HP = 5;
    public int Energy = 5;
    [SerializeField] private Transform turretGrp01;
    [SerializeField] private Transform turretGrp02;
    [SerializeField] private Transform turretGrp03;
    private GameObject[] turrets01;
    private GameObject[] turrets02;
    private GameObject[] turrets03;

    void Start()
    {
        UpdateAllArray();
       CheckAllTurrets();
    }

    public void UpdateAllArray()
    {
        turrets01 = GetTurretArray(turretGrp01);
        turrets02 = GetTurretArray(turretGrp02);
        turrets03 = GetTurretArray(turretGrp03);
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

    private GameObject[] GetTurretArray(Transform turretGrp)
    {
        if (turretGrp == null) return new GameObject[0];

        int count = turretGrp.childCount;
        GameObject[] tempTurretArray = new GameObject[count];
        for (int i = 0; i < count; i++)
            tempTurretArray[i] = turretGrp.GetChild(i).gameObject;
        return tempTurretArray;
    }

    public void CheckBaseEnergy(GameObject[] turrets)
    {

        if (turrets == null) return;
 
        

        foreach (GameObject turret in turrets)
        {
            if (turret == null) continue;

            int price = turret.GetComponent<TurretManager>().price;
            Image turretImage = turret.GetComponent<Image>();
            Color turretColor = turretImage.color;
            if (Energy < price)
            {
                turretColor.a = 0.2f;
            }
            else
            {
                turretColor.a = 1.0f;
             }

            turretImage.color = turretColor;
        }     
    }

    public void CheckAllTurrets()
    {
        UpdateAllArray();

  
        CheckBaseEnergy(turrets01);
 
        CheckBaseEnergy(turrets02);
   
        CheckBaseEnergy(turrets03);



    }
}
