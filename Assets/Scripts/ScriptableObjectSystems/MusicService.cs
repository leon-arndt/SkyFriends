using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace ScriptableObjectSystems
{
	[CreateAssetMenu(menuName = "Services/" + nameof(MusicService))]
	public class MusicService : ScriptableObject
	{
		[SerializeField] private List<TrackConfig> trackConfigs;
		[SerializeField] private float fadeSeconds = 3f;

		private readonly List<RuntimeTrack> runtimeTracks = new();

		public void Play(TrackType type)
		{
			if (!trackConfigs.Exists(x => x.trackType == type))
			{
				Debug.LogWarning($"Music track of type {type} not found in configs");
				return;
			}

			foreach (var track in runtimeTracks)
			{
				var outFadeVolume = track.source.volume;
				DOVirtual.Float(
					outFadeVolume,
					0f,
					fadeSeconds,
					(v) => track.source.volume = v
				);
			}

			if (!runtimeTracks.Exists(x => x.trackType == type))
			{
				var audioHolder = new GameObject(type.ToString());
				var audioSource = audioHolder.AddComponent<AudioSource>();
				audioSource.clip = trackConfigs.First(x => x.trackType == type).clip;
				audioSource.loop = true;
				audioSource.volume = 0f;
				audioSource.Play();
				runtimeTracks.Add(new RuntimeTrack { trackType = type, source = audioSource});
			}


			var targetTrack = runtimeTracks.FirstOrDefault(x => x.trackType == type);

			var currentVolume = targetTrack.source.volume;
			DOVirtual.Float(
				currentVolume,
				1f,
				fadeSeconds,
				(v) => targetTrack.source.volume = v
			);
		}

		public enum TrackType
		{
			HomeTown,
			Exploring
		}

		private struct RuntimeTrack
		{
			public TrackType trackType;
			public AudioSource source;
		}

		[System.Serializable]
		public struct TrackConfig
		{
			public TrackType trackType;
			public AudioClip clip;
		}
	}
}
