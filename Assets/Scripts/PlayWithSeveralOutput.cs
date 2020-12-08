using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.Experimental.Playables;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(RenderTexture))]
public class PlayWithSeveralOutput : MonoBehaviour
{
    public AnimationClip animationClip0;
    public AnimationClip animationClip1;
    public AnimationClip animationClip2;
    public AnimationClip animationClip3;

    public AudioClip audioClip0;
    public AudioClip audioClip1;

    public RenderTexture texture0;
    public RenderTexture texture1;

    public float weight0;
    public float weight1;


    PlayableGraph playableGraph;
    AnimationMixerPlayable animationMixerPlayable0;
    AnimationMixerPlayable animationMixerPlayable1;
    AudioMixerPlayable audioMixerPlayable;
    TextureMixerPlayable textureMixerPlayable;

    // Start is called before the first frame update
    void Start()
    {
        playableGraph = PlayableGraph.Create("Play With Several Output");

        // Creates the graph, the mixer and binds them to the Animator.

        var animationOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", GetComponent<Animator>());
        var audioOutput = AudioPlayableOutput.Create(playableGraph, "Audio", GetComponent<AudioSource>());
        var texturePlayableOutput = TexturePlayableOutput.Create(playableGraph, "Texture", GetComponent<RenderTexture>());

        animationMixerPlayable0 = AnimationMixerPlayable.Create(playableGraph, 3);
        animationMixerPlayable1 = AnimationMixerPlayable.Create(playableGraph, 2);
        
        animationOutput.SetSourcePlayable(animationMixerPlayable1);

        audioMixerPlayable = AudioMixerPlayable.Create(playableGraph, 2);
        audioOutput.SetSourcePlayable(audioMixerPlayable);

        textureMixerPlayable = TextureMixerPlayable.Create(playableGraph);
        texturePlayableOutput.SetSourcePlayable(textureMixerPlayable);

        // Creates AnimationClipPlayable\AudioClipPlayable and connects them to the mixer.

        var animationClipPlayable0 = AnimationClipPlayable.Create(playableGraph, animationClip0);
        var animationClipPlayable1 = AnimationClipPlayable.Create(playableGraph, animationClip1);
        var animationClipPlayable2 = AnimationClipPlayable.Create(playableGraph, animationClip2);
        var animationClipPlayable3 = AnimationClipPlayable.Create(playableGraph, animationClip3);

        playableGraph.Connect(animationClipPlayable0, 0, animationMixerPlayable0, 0);
        playableGraph.Connect(animationClipPlayable1, 0, animationMixerPlayable0, 1);
        playableGraph.Connect(animationClipPlayable2, 0, animationMixerPlayable0, 2);

        playableGraph.Connect(animationMixerPlayable0, 0, animationMixerPlayable1, 0);
        playableGraph.Connect(animationClipPlayable3, 0, animationMixerPlayable1, 1);

        var audioClipPlayable0 = AudioClipPlayable.Create(playableGraph, audioClip0, true);
        var audioClipPlayable1 = AudioClipPlayable.Create(playableGraph, audioClip1, true);

        playableGraph.Connect(audioClipPlayable0, 0, audioMixerPlayable, 0);
        playableGraph.Connect(audioClipPlayable1, 0, audioMixerPlayable, 1);

        // Plays the Graph.
        playableGraph.Play();

    }

    // Update is called once per frame
    void Update()
    {
        weight0 = Mathf.Clamp(weight0, -1, 1);
        weight1 = Mathf.Clamp01(weight1);

        if (weight0 < 0)
        {
            animationMixerPlayable0.SetInputWeight(0, Mathf.Abs(weight0));
            animationMixerPlayable0.SetInputWeight(1, 1.0f - Mathf.Abs(weight0));
            animationMixerPlayable0.SetInputWeight(2, 0);
        }
        else
        {
            animationMixerPlayable0.SetInputWeight(0, 0);
            animationMixerPlayable0.SetInputWeight(1, 1-weight0);
            animationMixerPlayable0.SetInputWeight(2, weight0);
        }

        animationMixerPlayable1.SetInputWeight(0, 1.0f - weight1);
        animationMixerPlayable1.SetInputWeight(1, weight1);

        audioMixerPlayable.SetInputWeight(0, 1.0f - weight1);
        audioMixerPlayable.SetInputWeight(1, weight1);
    }

    void OnDisable()
    {
        // Destroys all Playables and Outputs created by the graph.
        playableGraph.Destroy();

    }
}
