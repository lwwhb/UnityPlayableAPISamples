using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace TimelineSample2
{
    // A behaviour that is attached to a playable
    public class Sample2PlayableBehaviour : PlayableBehaviour
    {
        public Vector3 position;
        public Color color;

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
            if (trackBinding != null)
            {
                trackBinding.GetComponent<Transform>().position = position;
                trackBinding.GetComponent<Renderer>().sharedMaterial.color = color;
            }
        }
    }
}
