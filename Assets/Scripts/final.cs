using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    [SerializeField] private GameObject inventario;

    private void Start()
    {
        inventario.SetActive(false);
    }

    public void switchEnabled() 
    { 
        inventario.SetActive(false);
        KinematicManager.Instance.StartFinalDialogue();
    }


}
