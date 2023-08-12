using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAlien : InteractionManager
{
    public GameObject damage;
    [SerializeField] private Sprite icono;
    [SerializeField] private GameObject inventario;

    
    private void Update()
    {
        if (GameObject.FindWithTag("Inventario"))
        {
            inventario = GameObject.FindGameObjectWithTag("Inventario");
        }
    }

    public override void Interaction()
    {
        while(icono == null)
        {
            icono = gameObject.transform.GetChild(1).GetChild(Random.Range(0, gameObject.transform.GetChild(1).childCount)).GetComponent<SpriteRenderer>().sprite;
        }
        inventario.GetComponent<Inventario>().addItem(icono);
        Destroy(gameObject);
    }
}
