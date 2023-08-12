using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeIteraction
{
    ALIEN, PORTAL
}

public abstract class InteractionManager : MonoBehaviour
{
    
    [SerializeField] private TypeIteraction typeIteraction;
    [SerializeField] private GameObject text;

    public TypeIteraction Type() { return typeIteraction; }

    public abstract void Interaction();

    private void OnMouseEnter()
    {
        text.SetActive(true);
    }

    private void OnMouseExit()
    {
        text.SetActive(false);
    }

}
