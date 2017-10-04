using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Action : ScriptableObject
{
    // public abstract void Execute(StateController controller);

    public virtual void Execute(CharacterStateController controller) { }

    public virtual void Execute(EnemiesAIStateController controller) { }
}
