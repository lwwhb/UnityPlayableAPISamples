using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimelineSample4
{
    [TrackClipType(typeof(Sample4PlayableAsset))]
    [TrackBindingType(typeof(GameObject))]
    public class Sample4CustomMixerTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<Sample4MixerPlayableBehaviour>.Create(graph, inputCount);
        }
    }
}
