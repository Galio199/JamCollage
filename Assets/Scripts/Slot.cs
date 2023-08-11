using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool empty;
    public Sprite icono;
    public Transform slotIcono;

    public void Start()=>slotIcono = transform.GetChild(0);

    public void UpdateSlot()=>slotIcono.GetComponent<Image>().sprite = icono;
}
