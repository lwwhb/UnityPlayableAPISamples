using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace TimelineSample4
{
    public class Sample4PlayableAsset : PlayableAsset
    {
        public Sample4PlayableBehaviour template;

        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            var playable = ScriptPlayable<Sample4PlayableBehaviour>.Create(graph, template);
            return playable;
        }
    }
}
