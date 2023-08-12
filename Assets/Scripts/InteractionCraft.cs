using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionCraft : InteractionManager
{
    [SerializeField] private GameObject inventario;

    [SerializeField] private GameObject craft;

    private void Update()
    {
        if (GameObject.FindWithTag("Inventario"))
        {
            inventario = GameObject.FindGameObjectWithTag("Inventario");
        }
    }

    public override void Interaction()
    {
        craft.SetActive(true);
        inventario.GetComponent<Inventario>().removeItem();
    }
}
