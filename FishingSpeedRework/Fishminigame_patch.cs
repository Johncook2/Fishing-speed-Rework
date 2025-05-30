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
			if (__instance.isGameRunning) {
				__instance.indicatorAngle += -10 * Time.deltaTime * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier + __instance.difficultyConfig.rotationSpeed * Time.deltaTime;
			}
		}
	}
}
