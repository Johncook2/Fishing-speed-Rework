using UnityEngine;
using Winch.Core;
using HarmonyLib;
using System.CodeDom;

namespace FishingSpeedRework.BallCatcherminigame.Patches
{
	[HarmonyPatch(typeof(BallCatcherMinigame), "StartGame")]
	public static class BallCatcherminigame_StartGame_Patch
	{
		[HarmonyPostfix]
		static void StartGame(BallCatcherMinigame __instance)
		{
			__instance.equipmentSpeed = (float)1;
		}
	}

	[HarmonyPatch(typeof(BallCatcherBall), "Init")]
	public static class BallCatcherBall_Init_Patch
	{
		[HarmonyPrefix]
		static void Init(BallCatcherBall __instance)
		{


			if (__instance.speed > 0) { __instance.speed = 80 * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier; }
			if (__instance.speed < 0) { __instance.speed = -80 * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier; }
		}
	}
	
	[HarmonyPatch(typeof(BallCatcherMinigame), "Update")]
	public static class BallCatcherMinigame_Update_Patch
	{
        [HarmonyPrefix]
    	static void Update(BallCatcherMinigame __instance)
		{
			__instance.ballDelaySec -= Time.deltaTime * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier / 10 + Time.deltaTime;
		}
	}
}
