using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

namespace TimelineSample2
{
    [TrackClipType(typeof(Sample2PlayableAsset))]
    [TrackBindingType(typeof(GameObject))]
    public class Sample2CustomTrack : TrackAsset
    {
    }
}
