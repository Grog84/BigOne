using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class SwitchCharacterMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

        int inputCount = playable.GetInputCount ();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<SwitchCharacterBehaviour> inputPlayable = (ScriptPlayable<SwitchCharacterBehaviour>)playable.GetInput(i);
            SwitchCharacterBehaviour input = inputPlayable.GetBehaviour ();

            if(inputWeight > 0.5f && !input.characterSwitched)
            {
                if (GMController.instance.isCharacterPlaying == CharacterActive.Boy)
                {
                    GMController.instance.isCharacterPlaying = CharacterActive.Mother;
                }
                else
                {
                    GMController.instance.isCharacterPlaying = CharacterActive.Boy;
                }
                input.characterSwitched = true;
            }

            // Use the above variables to process each frame of this playable.

        }
    }
}
