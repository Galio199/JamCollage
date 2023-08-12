using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;

    public void OnDrop(PointerEventData eventData)
    {
        item = DragItem.itemDragging;
        item.transform.SetParent(transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("boton").GetComponent<Button>().switchEnabled();
        GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>().removeItem();
    }

}
