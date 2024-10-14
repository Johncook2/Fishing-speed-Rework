using UnityEngine;
using Winch.Core;
using HarmonyLib;
using System.CodeDom;

namespace FishingSpeedRework.BallCatcherminigame.Patches
{
	[HarmonyPatch(typeof(BallCatcherminigame), "StartGame")]
	public static class BallCatcherminigame_StartGame_Patch
	{
        [HarmonyPostfix]
    	static void StartGame(BallCatcherminigame __instance)
		{
			__instance.equipmentSpeed = (float)1;
		}
	}

	[HarmonyPatch(typeof(BallCatcherBall), "Init")]
	public static class BallCatcherBall_Init_Patch
	{
        [HarmonyPostfix]
    	static void Init(BallCatcherBall __instance)
		{
			

            if (__instance.speed > 0) { __instance.speed = 1 * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier; }
	    if (__instance.speed < 0) { __instance.speed = -1 * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier; }
		}
	}
}
