using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/ResetAnimator")]
    public class ResetAnimator : _Action
    {

        public override void Execute(GMStateController controller)
        {
            ResAnim(controller);
        }

        private void ResAnim(GMStateController controller)
        {
            foreach (var ci in controller.m_GM.m_CharacterInterfaces)
            {
                ci.ResetAnimator();
            }

        }
    }
}
