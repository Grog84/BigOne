using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;


public class SwitchOffBkgMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

        int inputCount = playable.GetInputCount ();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<SwitchOffBkgBehaviour> inputPlayable = (ScriptPlayable<SwitchOffBkgBehaviour>)playable.GetInput(i);
            SwitchOffBkgBehaviour input = inputPlayable.GetBehaviour ();

            if(inputWeight > 0.5f && !input.done)
            {
                //SceneManager.LoadScene(input.nextScene);
                GMController.instance.SetBkgMusicActive(false);
                input.done = true;
            }

            // Use the above variables to process each frame of this playable.

        }
    }
}
