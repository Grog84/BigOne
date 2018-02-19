using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class DisableGuardMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

        int inputCount = playable.GetInputCount ();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<DisableGuardsBehaviour> inputPlayable = (ScriptPlayable<DisableGuardsBehaviour>)playable.GetInput(i);
            DisableGuardsBehaviour input = inputPlayable.GetBehaviour ();

            if(inputWeight > 0.5f && !input.guardDisabled)
            {
                if(input.disableGuards)
                {
                    GMController.instance.DeactivateAllGuards();
                }
                else
                {
                    GMController.instance.ActivateAllGuards();
                }
                input.guardDisabled = true;
            }

            // Use the above variables to process each frame of this playable.

        }
    }
}
