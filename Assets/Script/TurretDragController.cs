using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretDragController : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0){
        GameObject dropped = eventData.pointerDrag;
        DragHandler draggedTurret = dropped.GetComponent<DragHandler>();
        draggedTurret.PositionAfterDrag = transform;
        }
    }
}
