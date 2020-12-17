using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace TimelineSample3
{
    // A behaviour that is attached to a playable
    public class Sample3MixerPlayableBehaviour : PlayableBehaviour
    {
        // Called when the owning graph starts playing
        public override void OnGraphStart(Playable playable)
        {

        }

        // Called when the owning graph stops playing
        public override void OnGraphStop(Playable playable)
        {

        }

        // Called when the state of the playable is set to Play
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {

        }

        // Called when the state of the playable is set to Paused
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {

        }

        // Called each frame while the state is set to Play
        public override void PrepareFrame(Playable playable, FrameData info)
        {
            
        }
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            GameObject trackBinding = playerData as GameObject;
            if (!trackBinding)
                return;

            Color finalColor = Color.black;
            Vector3 finalPosition = Vector3.zero;
            
            int inputCount = playable.GetInputCount(); //get the number of all clips on this track

            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                ScriptPlayable<Sample3PlayableBehaviour> inputPlayable = (ScriptPlayable<Sample3PlayableBehaviour>)playable.GetInput(i);
                Sample3PlayableBehaviour input = inputPlayable.GetBehaviour();

                // Use the above variables to process each frame of this playable
                finalColor += input.color * inputWeight;
                finalPosition += input.position * inputWeight;
            }

            //assign the result to the bound object
            trackBinding.GetComponent<Renderer>().sharedMaterial.color = finalColor;
            trackBinding.GetComponent<Transform>().position = finalPosition;
        }
    }
}
