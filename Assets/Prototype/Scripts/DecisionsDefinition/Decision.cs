using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : ScriptableObject {

    public virtual bool Decide(CharacterStateController controller) { return true; }

    public virtual bool Decide(EnemiesAIStateController controller) { return true; }

}
