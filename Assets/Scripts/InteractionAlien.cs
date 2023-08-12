using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAlien : InteractionManager
{
    public GameObject damage;

    public override void Interaction()
    {
        Destroy(gameObject);
    }
}
