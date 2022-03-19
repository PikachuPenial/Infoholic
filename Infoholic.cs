using System;
using System.Collections;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using TMPro;
using UnboundLib;
using UnboundLib.GameModes;
using UnboundLib.Utils.UI;
using Infoholic.MonoBehaviours;
using Infoholic.UI;
using UnityEngine;

namespace Infoholic
{
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("com.penial.rounds.Infoholic", "Infoholic", "0.0.1")]
    [BepInProcess("Rounds.exe")]

    public class Infoholic : BaseUnityPlugin
    {
        public const string AbbrModName = "IH";
        public const string ModInitials = "IH";
        private const string ModId = "com.penial.rounds.Infoholic";
        private const string ModName = "Infoholic";
        public const string Version = "0.0.1";
        private const string CompatibilityModName = "Infoholic";
        public static Infoholic instance { get; private set; }

        void Awake()
        {
            Infoholic.instance = this;
            Unbound.RegisterClientSideMod("com.penial.rounds.Infoholic");
            var harmony = new Harmony("com.penial.rounds.Infoholic");
            harmony.PatchAll();
        }

        void Start()
        {
            UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] Mod is loaded (somehow.)");

            GameModeManager.AddHook(GameModeHooks.HookGameStart, this.GameStart);
            GameModeManager.AddHook(GameModeHooks.HookGameEnd, this.GameEnd);

            ToggleGameUI.Initialize();
        }

        private IEnumerator GameStart(IGameModeHandler gameModeHandler)
        {
            ToggleGameUI.inGame = true;
            GameStatusUpdate gameStatusUpdate = new GameObject().AddComponent<GameStatusUpdate>();
            UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] inGame is now true.");
            yield break;
        }

        private IEnumerator GameEnd(IGameModeHandler gameModeHandler)
        {
            ToggleGameUI.inGame = false;
            UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] inGame is now false.");
            yield break;
        }
    }
}