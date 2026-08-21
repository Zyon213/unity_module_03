using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretDragController : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool isTurretLocation;
    public bool isTurretPlaced = false;
 
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0 && isTurretLocation){
            GameObject dropped = eventData.pointerDrag;
            DragHandler draggedTurret = dropped.GetComponent<DragHandler>();
            TurretManager turretManager = dropped.GetComponent<TurretManager>();

            BaseControl baseControl = FindObjectOfType<BaseControl>();
            if (baseControl.Energy >= turretManager.price)
            {

            draggedTurret.PositionAfterDrag = transform;
            isTurretPlaced = true;
                {
                    baseControl.Energy -= turretManager.price;
                    baseControl.CheckBaseEnergy();
                }
                Debug.Log("Base Energy " + baseControl.Energy);
            }
        }
    }
}
