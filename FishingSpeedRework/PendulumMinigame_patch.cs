using UnityEngine;
using Winch.Core;
using HarmonyLib;
using System.CodeDom;

namespace FishingSpeedRework.Pendulumminigame.Patches
{
	[HarmonyPatch(typeof(PendulumMinigame), "StartGame")]
	public static class PendulumMinigame_StartGame_Patch
	{
        [HarmonyPostfix]
    	static void StartGame(PendulumMinigame __instance)
		{
			__instance.equipmentSpeed = (float)1;
		}
	}

	[HarmonyPatch(typeof(PendulumMinigame), "Update")]
	public static class PendulumMinigame_Update_Patch
	{
        [HarmonyPrefix]
    	static void Update(PendulumMinigame __instance)
		{
			if (__instance.isPendulumSwingingRight)
			{
				__instance.indicatorAngle += __instance.difficultyConfig.rotationSpeed * Time.deltaTime + -5 * Time.deltaTime * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier;
				
			}
			else
			{
				__instance.indicatorAngle -= __instance.difficultyConfig.rotationSpeed * Time.deltaTime + -5 * Time.deltaTime * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier;
				
			}
		}
	}
}
