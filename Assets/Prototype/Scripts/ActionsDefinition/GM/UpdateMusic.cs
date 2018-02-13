using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/UpdateMusic")]
    public class UpdateMusic : _Action
    {
        public override void Execute(GMStateController controller)
        {
            MusicUpdate(controller);
        }

        private void MusicUpdate(GMStateController controller)
        {
            if (GMController.instance.curiousGuards > 0 || GMController.instance.alarmedGuards > 0)
            {
                float detectionLevel = 0;

                for (int i = 0; i < GMController.instance.allGuards.Length; i++)
                {
                    detectionLevel = Mathf.Max(detectionLevel, GMController.instance.allGuards[i].GetPerceptionValue());
                }

                GMController.instance.SetBkgMusicState(detectionLevel);
            }
            else
            {
                GMController.instance.SetBkgMusicState(0f);
            }
        }
    }
}
