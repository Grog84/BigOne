using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _Action : ScriptableObject
{
    public abstract void Execute(StateController controller);
}
