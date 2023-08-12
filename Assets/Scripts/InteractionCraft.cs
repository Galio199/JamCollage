using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionCraft : InteractionManager
{
    public override void Interaction()
    {
        KinematicManager.Instance.StartFinalDialogue();
    }
}
