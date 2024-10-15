using UnityEngine;
using Winch.Core;
using HarmonyLib;
using System.CodeDom;

namespace FishingSpeedRework.PendulumMinigame.Patches
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
			if (this.isPendulumSwingingRight)
			{
				this.indicatorAngle -= -this.difficultyConfig.rotationSpeed * Time.deltaTime + __instance.difficultyConfig.rotationSpeed * Time.deltaTime * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier;
				
			}
			else
			{
				this.indicatorAngle += -this.difficultyConfig.rotationSpeed * Time.deltaTime + __instance.difficultyConfig.rotationSpeed * Time.deltaTime * GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier;
				
			}
		}
	}
}
