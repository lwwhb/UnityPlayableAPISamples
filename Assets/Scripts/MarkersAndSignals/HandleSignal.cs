using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class HandleSignal : MonoBehaviour
{
    public AnimationClip clip;
    PlayableGraph playableGraph;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        Reset();
    }
    public void ChangeColorToRed()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.red;
    }
    public void LogChangeColorToRed()
    {
        Debug.Log("RED");
    }
    public void ChangeColorToGreen()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.green;
    }
    public void LogChangeColorToGreen()
    {
        Debug.Log("Green");
    }
    public void Reset()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.white;
        Debug.Log("White");
    }
    public void PlayRotateAnimation()
    {
        GetComponent<Animation>().Play("RotationLegacy");
    }
    public void PlayPingPongXAnimation()
    {
        GetComponent<Animation>().Play("PingPongXLegacy");
    }
    public void PlayPingPongXPlayable()
    {
        playableGraph = PlayableGraph.Create("Play Single Animation");

        playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);

        var playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", GetComponent<Animator>());

        // Wrap the clip in a playable

        AnimationClipPlayable clipPlayable = AnimationClipPlayable.Create(playableGraph, clip);

        // Connect the Playable to an output

        playableOutput.SetSourcePlayable(clipPlayable);

        // Plays the Graph.

        playableGraph.Play();

    }
    void OnDisable()

    {

        // Destroys all Playables and PlayableOutputs created by the graph.

        playableGraph.Destroy();

    }
}
