using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimelineSample3
{
    [TrackClipType(typeof(Sample3PlayableAsset))]
    [TrackBindingType(typeof(GameObject))]
    public class Sample3CustomMixerTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<Sample3MixerPlayableBehaviour>.Create(graph, inputCount);
        }
    }
}
