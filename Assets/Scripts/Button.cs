using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject inventario;

    public void switchEnabled() => inventario.SetActive(!inventario.activeSelf);
}
