using UnityEngine;

namespace AI.BT
{
    public class Sequence : Composite
    {
        public override TaskState Run()
        {
            Debug.Log("Sequence Called, children count : " + children.Count);
            foreach (var child in children)
            {
                if (child.Run() == TaskState.FAILURE)
                    return TaskState.FAILURE;
            }
            return TaskState.SUCCESS;
        }
    }

}
