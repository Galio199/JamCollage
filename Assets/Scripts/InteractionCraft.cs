using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCraft : InteractionManager
{
    public override void Interaction()
    {
        KinematicManager.Instance.StartFinalDialogue();
    }
}
