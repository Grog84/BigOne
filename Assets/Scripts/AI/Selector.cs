using UnityEngine;

namespace AI.BT
{
    public class Selector : Composite
    {
        public override TaskState Run()
        {
            Debug.Log("Selector Called, children count : " + children.Count);
            foreach (var child in children)
            {
                if (child.Run() == TaskState.SUCCESS)
                    return TaskState.SUCCESS;
            }
            return TaskState.FAILURE;
        }
    }

}
