using UnityEngine;
using Winch.Core;

namespace FishingSpeedRework
{
	public class FishingSpeedRework : MonoBehaviour
	{
		public void Awake()
		{
			WinchCore.Log.Debug($"{nameof(FishingSpeedRework)} has loaded!");
		}
	}
}
