using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public class PlaySingleAnimation : MonoBehaviour
{
    public AnimationClip clip;
    public float time;
    public bool pause;

    PlayableGraph playableGraph;
    AnimationClipPlayable clipPlayable;

    // Start is called before the first frame update
    void Start()
    {
        playableGraph = PlayableGraph.Create("Play Single Animation");

        playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);

        var playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", GetComponent<Animator>());

        // Wrap the clip in a playable

        clipPlayable = AnimationClipPlayable.Create(playableGraph, clip);

        // Connect the Playable to an output

        playableOutput.SetSourcePlayable(clipPlayable);

        // Plays the Graph.

        playableGraph.Play();


        //AnimationPlayableUtilities.PlayClip(GetComponent<Animator>(), clip, out playableGraph);

    }

    // Update is called once per frame
    void Update()
    {
        if (pause)
        {
            clipPlayable.Pause();
            clipPlayable.SetTime(time);
        }
        else
            clipPlayable.Play();
    }
    void OnDisable()

    {

        // Destroys all Playables and PlayableOutputs created by the graph.

        playableGraph.Destroy();

    }
}
