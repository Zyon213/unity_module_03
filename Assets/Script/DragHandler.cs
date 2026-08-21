using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [SerializeField] private GameObject playerBase;
    private BaseControl baseControl;
    private TurretManager turretManager;
    private TurretDragController turretDragController;
    private bool isDragging = false;
   // private bool isDragged = false;

    private void Start()
    {
        turretManager = GetComponent<TurretManager>();
        baseControl = playerBase.GetComponent<BaseControl>();
    }

    [HideInInspector] public Transform PositionAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        turretDragController = transform.parent.GetComponent<TurretDragController>();
        if (turretDragController.isTurretPlaced)
        {
            isDragging = false;
            return;
        }
        if (baseControl.Energy >= turretManager.price)
        {
            PositionAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
            isDragging = true;
        }
        else
            isDragging = false;
        
   
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragging) return;
        isDragging = false;
        transform.SetParent(PositionAfterDrag);
        image.raycastTarget = true;
    }



}
