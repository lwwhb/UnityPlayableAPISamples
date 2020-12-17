using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimelineSample3
{
    [System.Serializable]
    public class Sample3PlayableAsset : PlayableAsset, ITimelineClipAsset
    {
        public Vector3 position;
        public Color color = Color.white;

        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<Sample3PlayableBehaviour>.Create(graph);
            var behaviour = playable.GetBehaviour();

            behaviour.position = position;
            behaviour.color = color;

            return playable;
        }
    }
}