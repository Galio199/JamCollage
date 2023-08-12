using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionPortal : InteractionManager
{
    [SerializeField] private string Scene;

    public override void Interaction()
    {
        SceneManager.LoadScene(Scene);
    }



}
