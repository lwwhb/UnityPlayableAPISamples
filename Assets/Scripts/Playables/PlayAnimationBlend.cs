﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Playables;

using UnityEngine.Animations;

[RequireComponent(typeof(Animator))]
public class PlayAnimationBlend : MonoBehaviour
{
    public AnimationClip clip0;

    public AnimationClip clip1;

    public float weight;

    public bool pauseClip0;
    public bool pauseClip1;
    public bool mixerPause;

    PlayableGraph playableGraph;

    AnimationMixerPlayable mixerPlayable;


    // Start is called before the first frame update
    void Start()
    {
        // Creates the graph, the mixer and binds them to the Animator.

        playableGraph = PlayableGraph.Create("Play Animation Blend");

        var playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", GetComponent<Animator>());

        mixerPlayable = AnimationMixerPlayable.Create(playableGraph, 2);

        playableOutput.SetSourcePlayable(mixerPlayable);

        // Creates AnimationClipPlayable and connects them to the mixer.

        var clipPlayable0 = AnimationClipPlayable.Create(playableGraph, clip0);

        var clipPlayable1 = AnimationClipPlayable.Create(playableGraph, clip1);

        playableGraph.Connect(clipPlayable0, 0, mixerPlayable, 0);

        playableGraph.Connect(clipPlayable1, 0, mixerPlayable, 1);

        // Plays the Graph.

        playableGraph.Play();


        /*mixerPlayable = AnimationPlayableUtilities.PlayMixer(GetComponent<Animator>(), 2, out playableGraph);
        var clipPlayable0 = AnimationClipPlayable.Create(playableGraph, clip0);
        var clipPlayable1 = AnimationClipPlayable.Create(playableGraph, clip1);
        playableGraph.Connect(clipPlayable0, 0, mixerPlayable, 0);
        playableGraph.Connect(clipPlayable1, 0, mixerPlayable, 1);*/



    }

    // Update is called once per frame
    void Update()
    {
        if (pauseClip0)
            mixerPlayable.GetInput(0).Pause();
        else
            mixerPlayable.GetInput(0).Play();

        if (pauseClip1)
            mixerPlayable.GetInput(1).Pause();
        else
            mixerPlayable.GetInput(1).Play();

        if (mixerPause)
            mixerPlayable.Pause();
        else
            mixerPlayable.Play();

        weight = Mathf.Clamp01(weight);

        mixerPlayable.SetInputWeight(0, 1.0f - weight);

        mixerPlayable.SetInputWeight(1, weight);
    }

    void OnDisable()

    {

        // Destroys all Playables and PlayableOutputs created by the graph.

        playableGraph.Destroy();

    }
}
