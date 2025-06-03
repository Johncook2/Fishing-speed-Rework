using UnityEngine;
using Winch.Core;
using HarmonyLib;
using System.CodeDom;

namespace FishingSpeedRework.Fishminigame.Patches
{
	[HarmonyPatch(typeof(FishMinigame), "StartGame")]
	public static class FishMinigame_StartGame_Patch
	{
		[HarmonyPostfix]
		static void StartGame(FishMinigame __instance)
		{
			__instance.equipmentSpeed = (float)1;
		}
	}

	[HarmonyPatch(typeof(FishMinigame), "Update")]
	public static class FishMinigame_Update_Patch
	{
		[HarmonyPrefix]
		static void Update(FishMinigame __instance)
		{
			if (__instance.isGameRunning)
			{
				__instance.indicatorAngle += -80 * Time.deltaTime * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier + __instance.difficultyConfig.rotationSpeed * Time.deltaTime;
			}
		}
	}
	
	[HarmonyPatch(typeof(HarvestMinigame), "Update")]
	public static class HarvestMinigame_Update_Patch
	{
        [HarmonyPrefix]
    	static void Update(HarvestMinigame __instance)
		{
			if (__instance.progressDisabled)
		{
			__instance.progressChange = 0f;
		}
		else if (__instance.currentPOI.IsDredgePOI)
		{
			__instance.progressChange = 1f / (__instance.difficultyConfig.secondsToPassivelyCatch / __instance.equipmentSpeed) * Time.deltaTime;
		}
		else
		{
			__instance.progressChange = 1f / __instance.difficultyConfig.secondsToPassivelyCatch * Time.deltaTime;
		}
		__instance.progress += __instance.progressChange /2 - __instance.progressChange;
		}
	}
}
