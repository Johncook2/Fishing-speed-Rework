using UnityEngine;
using Winch.Core;
using HarmonyLib;
using System.CodeDom;

namespace FishingSpeedRework.Spiralminigame.Patches
{
	[HarmonyPatch(typeof(SpiralMinigame), "StartGame")]
	public static class SpiralMinigame_StartGame_Patch
	{
        [HarmonyPostfix]
    	static void StartGame(SpiralMinigame __instance)
		{
			__instance.equipmentSpeed = (float)1;
		}
	}

	[HarmonyPatch(typeof(SpiralMinigame), "Update")]
	public static class SpiralMinigame_Update_Patch
	{
        [HarmonyPrefix]
    	static void Update(SpiralMinigame __instance)
		{
			if (__instance.isGameRunning) {
                if (__instance.movingForward)
				{
                    __instance.currentBallProgressProp += 40 * __instance.baseSpeed * Time.deltaTime * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier - __instance.difficultyConfig.spiralRotationSpeed * Time.deltaTime * __instance.baseSpeed;
				}
            else { 
                __instance.currentBallProgressProp -= 404 * __instance.baseSpeed * Time.deltaTime * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier - __instance.difficultyConfig.spiralRotationSpeed * Time.deltaTime * __instance.baseSpeed;
				}
			}
		}
	}
}
