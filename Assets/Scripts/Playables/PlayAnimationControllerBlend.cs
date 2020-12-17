using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public class PlayAnimationControllerBlend : MonoBehaviour
{
    public AnimationClip clip;

    public RuntimeAnimatorController controller;

    public float weight;

    PlayableGraph playableGraph;

    AnimationMixerPlayable mixerPlayable;
    // Start is called before the first frame update
    void Start()
    {
       /* // Creates the graph, the mixer and binds them to the Animator.

        playableGraph = PlayableGraph.Create("Play AnimationController Blend");

        var playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", GetComponent<Animator>());

        mixerPlayable = AnimationMixerPlayable.Create(playableGraph, 2);

        playableOutput.SetSourcePlayable(mixerPlayable);

        // Creates AnimationClipPlayable and connects them to the mixer.

        var clipPlayable = AnimationClipPlayable.Create(playableGraph, clip);

        var ctrlPlayable = AnimatorControllerPlayable.Create(playableGraph, controller);

        playableGraph.Connect(clipPlayable, 0, mixerPlayable, 0);

        playableGraph.Connect(ctrlPlayable, 0, mixerPlayable, 1);

        // Plays the Graph.

        playableGraph.Play();*/


        mixerPlayable = AnimationPlayableUtilities.PlayMixer(GetComponent<Animator>(), 2, out playableGraph);
        var clipPlayable = AnimationClipPlayable.Create(playableGraph, clip);
        var ctrlPlayable = AnimatorControllerPlayable.Create(playableGraph, controller);
        playableGraph.Connect(clipPlayable, 0, mixerPlayable, 0);
        playableGraph.Connect(ctrlPlayable, 0, mixerPlayable, 1);
    }

    // Update is called once per frame
    void Update()
    {
        weight = Mathf.Clamp01(weight);

        mixerPlayable.SetInputWeight(0, 1.0f - weight);

        mixerPlayable.SetInputWeight(1, weight);
    }

    void OnDisable()
    {

        // Destroys all Playables and Outputs created by the graph.

        playableGraph.Destroy();

    }

}
