using UnityEngine;
using Winch.Core;
using HarmonyLib;
using System.CodeDom;

namespace FishingSpeedRework.Diamondminigame.Patches
{
	[HarmonyPatch(typeof(DiamondMinigame), "StartGame")]
	public static class DiamondMinigame_StartGame_Patch
	{
        [HarmonyPostfix]
    	static void StartGame(DiamondMinigame __instance)
		{
			__instance.equipmentSpeed = (float)1;
		}
	}

	[HarmonyPatch(typeof(DiamondMinigame), "Firetarget")]
	public static class DiamondMinigame_Firetarget_Patch
	{
        [HarmonyPrefix]
    	static void Firetarget(DiamondMinigame __instance)
		{

			__instance.difficultyConfig.diamondRotation =  GameManager.Instance.PlayerStats.MinigameFishingSpeedModifier * 1;

		}
	}
}
