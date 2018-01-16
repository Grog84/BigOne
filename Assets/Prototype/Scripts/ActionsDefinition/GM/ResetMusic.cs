using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/ResetMusic")]
    public class ResetMusic : _Action
    {
        public override void Execute(GMStateController controller)
        {
            MusicReset(controller);
        }

        private void MusicReset(GMStateController controller)
        {
            
                GMController.instance.SetBkgMusicState(0f);
        }
    }
}
