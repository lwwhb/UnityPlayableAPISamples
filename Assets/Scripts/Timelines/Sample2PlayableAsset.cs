using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace TimelineSample2
{
    [System.Serializable]
    public class Sample2PlayableAsset : PlayableAsset
    {
        public Vector3 position;
        public Color color = Color.white;
        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<Sample2PlayableBehaviour>.Create(graph);
            var behaviour = playable.GetBehaviour();

            behaviour.position = position;
            behaviour.color = color;

            return playable;
        }
    }
}
