using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace TimelineSample1
{
	[System.Serializable]
	public class Sample1PlayableAsset : PlayableAsset
	{
		public ExposedReference<GameObject> gameobject;
		public Vector3 position;
		public Color color = Color.white;
		// Factory method that generates a playable based on this asset
		public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
		{
			var playable = ScriptPlayable<Sample1PlayableBehaviour>.Create(graph);
			var behaviour = playable.GetBehaviour();

			behaviour.gameobject = gameobject.Resolve(graph.GetResolver());
			behaviour.position = position;
			behaviour.color = color;

			return playable;
		}
	}
}
