using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public GameObject itemDragging;

    Vector3 posicionIni;
    Transform parentIni;
    Transform parentDrag;

    void Start()
    {
        parentDrag = GameObject.FindGameObjectWithTag("DragParent").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemDragging = gameObject;

        posicionIni = transform.position;
        parentIni = transform.parent;
        transform.SetParent(parentDrag);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemDragging = null;

        if(transform.parent == parentDrag)
        {
            transform.position = posicionIni;
            transform.SetParent(parentIni);
        }
    }

    void Update()
    {
        
    }
}
