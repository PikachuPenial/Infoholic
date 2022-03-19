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
using Infoholic.Utilities;
using UnityEngine;
using UnityEngine.UI;

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

        public bool inGame;

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
            UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] Mod is loaded.");

            Unbound.RegisterCredits("<b><color=#09ff00>I</color>nfo<color=#ff0000>h</color>olic</b>", new string[]
            {
                "Penial"
            }, new string[]
            {
                "<b><color=#ff00df>GitHub (Source Code)</b></color>",
                "Penial's Steam Profile",
            }, new string[]
            {
                "https://github.com/PikachuPenial/Infoholic",
                "https://steamcommunity.com/id/penialsteamlol",
            });

            Unbound.RegisterMenu("<b>Infoholic Settings</b>", delegate ()
            {
            }, new Action<GameObject>(this.NewGUI), null, true);

            GameModeManager.AddHook(GameModeHooks.HookGameStart, this.GameStart);
            GameModeManager.AddHook(GameModeHooks.HookGameEnd, this.GameEnd);
        }

        private IEnumerator GameStart(IGameModeHandler gameModeHandler)
        {
            inGame = true;
            GameStatusUpdate gameStatusUpdate = new GameObject().AddComponent<GameStatusUpdate>();
            UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] inGame is now true.");
            yield break;
        }

        private IEnumerator GameEnd(IGameModeHandler gameModeHandler)
        {
            inGame = false;
            UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] inGame is now false.");
            yield break;
        }

        private void NewGUI(GameObject menu)
        {
            TextMeshProUGUI textMeshProUGUI;
            MenuHandler.CreateText("Infoholic Settings", menu, out textMeshProUGUI, 60, true, null, null, null, null);
            GameObject toggle = MenuHandler.CreateToggle(Infoholic.settingsEnableMod, "<b><color=#09ff00>Enable Mod<b></color>", menu, delegate (bool value)
            {
                if (inGame)
                {
                    GameStatusUpdate gameStatusUpdate = new GameObject().AddComponent<GameStatusUpdate>();
                }

                Infoholic.settingsEnableMod = value;
            }, 50, true, null, null, null, null);
        }

        public static bool settingsEnableMod
        {
            get
            {
                return PlayerPrefs.GetInt(Infoholic.GetConfigKey("settingsEnableMod"), 1) == 1;
            }
            set
            {
                PlayerPrefs.SetInt(Infoholic.GetConfigKey("settingsEnableMod"), value ? 1 : 0);
            }
        }

        private static string GetConfigKey(string key)
        {
            return "IH_" + key;
        }
    }
}