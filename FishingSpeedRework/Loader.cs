using UnityEngine;

namespace FishingSpeedRework
{
	public class Loader
	{
		/// <summary>
		/// This method is run by Winch to initialize your mod
		/// </summary>
		public static void Initialize()
		{
			var gameObject = new GameObject(nameof(FishingSpeedRework));
			gameObject.AddComponent<FishingSpeedRework>();
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}