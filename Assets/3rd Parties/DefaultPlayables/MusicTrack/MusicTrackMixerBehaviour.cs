using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using AI;

public class MusicTrackMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

        AudioSource trackBinding = playerData as AudioSource;

        if (!trackBinding)
            return;

        int inputCount = playable.GetInputCount ();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<MusicTrackBehaviour> inputPlayable = (ScriptPlayable<MusicTrackBehaviour>)playable.GetInput(i);
            MusicTrackBehaviour input = inputPlayable.GetBehaviour ();

            if(inputWeight > 0.5f && !input.musicPlayed)
            {
                if(input.forTheLolis)
                {
                    input.Music.setVolume(0);
                    input.SFX.setVolume(0);
                    trackBinding.PlayOneShot(trackBinding.clip);          
                }
                else if(!input.forTheLolis)
                {
                    input.Music.setVolume(GameObject.Find("EmptyPauseMenuUIManager").GetComponent<PauseMenuUIManager>().MusicVolume);
                    input.SFX.setVolume(GameObject.Find("EmptyPauseMenuUIManager").GetComponent<PauseMenuUIManager>().MusicVolume);
                }
                input.musicPlayed = true;
            }

            // Use the above variables to process each frame of this playable.

        }
    }
}
