using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    private bool inventorioEnabled;

    [SerializeField] private int numSlots;

    private int enabledSlots;

    private GameObject[] slot;

    [SerializeField] private GameObject espacio;


    private void Start()
    { 
        espacio = transform.GetChild(0).gameObject;

        numSlots = espacio.transform.childCount;

        slot = new GameObject[numSlots];

        for (int i = 0; i < numSlots; i++)
        {
            slot[i] = espacio.transform.GetChild(i).gameObject;

            slot[i].GetComponent<Slot>().empty = true;
        }
    }

    public void addItem(Sprite icono)
    {
        for(int i  = 0; i < numSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                slot[i].GetComponent<Slot>().icono = icono;

                slot[i].GetComponent<Slot>().UpdateSlot();

                slot[i].GetComponent<Slot>().empty = false;

                return;
            }
        }
    }
}
