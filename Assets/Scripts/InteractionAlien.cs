using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAlien : InteractionManager
{
    public GameObject damage;
    [SerializeField] private Sprite icono;

    public override void Interaction()
    {
        GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>().addItem(icono);
        Destroy(gameObject);
    }
}
