using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/FadeOutOver")]
    public class FadeOutOver : _Action
    {

        public override void Execute(GMStateController controller)
        {
            FadeOutEnd(controller);
        }

        private void FadeOutEnd(GMStateController controller)
        {
            //Debug.Log("Fade Out");
            GMController.instance.fadeOutFinished = true;
        }
    }
}
