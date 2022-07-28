using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObjectSystems
{
	[CreateAssetMenu(menuName = "Services/" + nameof(MusicService))]
	public class MusicService : ScriptableObject
	{
		[SerializeField] private List<TrackConfig> trackConfigs;

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
				track.source.volume = 0f;
			}

			if (!runtimeTracks.Exists(x => x.trackType == type))
			{
				var audioHolder = new GameObject(type.ToString());
				var audioSource = audioHolder.AddComponent<AudioSource>();
				audioSource.clip = trackConfigs.First(x => x.trackType == type).clip;
				audioSource.loop = true;
				audioSource.Play();
				runtimeTracks.Add(new RuntimeTrack { trackType = type, source = audioSource});
			}

			runtimeTracks.FirstOrDefault(x => x.trackType == type).source.volume = 1f;
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
