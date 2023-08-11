using UnityEngine;

public class Boton : MonoBehaviour
{
    [SerializeField] private GameObject inventario;

    public void switchEnabled()=>inventario.SetActive(!inventario.activeSelf);
}
