using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineBinder : MonoBehaviour
{
	public PlayableDirector playableDirector;
	public Animator objectToBind;
	public string trackName;

	private void Start()
	{
		foreach (var playableAssetOutput in playableDirector.playableAsset.outputs)
		{
			if (playableAssetOutput.streamName == trackName)
			{
				playableDirector.SetGenericBinding(playableAssetOutput.sourceObject, objectToBind);
			}
		}

		playableDirector.Play();
	}
}