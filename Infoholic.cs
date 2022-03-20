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

        public static bool inGame;
        public static bool inPick;
        public static bool inBattle;
        public static bool inSettings;
        public static bool inSandbox;

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
            Unbound.RegisterCredits("<b><color=#09ff00>I</color>nfo<color=#ff0000>h</color>olic</b> (BETA)", new string[]
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

            Unbound.RegisterMenu("<b>Infoholic Settings (BETA)</b>", delegate ()
            {
                Infoholic.inSettings = true;

                SettingsPreview settingsPreview = new GameObject().AddComponent<SettingsPreview>();

            }, new Action<GameObject>(this.NewGUI), null, false);

            GameModeManager.AddHook(GameModeHooks.HookGameStart, this.GameStart);
            GameModeManager.AddHook(GameModeHooks.HookGameEnd, this.GameEnd);

            GameModeManager.AddHook(GameModeHooks.HookPickStart, this.PickStart);
            GameModeManager.AddHook(GameModeHooks.HookPickEnd, this.PickEnd);
        }

        private IEnumerator GameStart(IGameModeHandler gameModeHandler)
        {
            inGame = true;

            if (SettingsEnableMod)
            {
                GameStatusUpdate gameStatusUpdate = new GameObject().AddComponent<GameStatusUpdate>();
            }

            InfoholicDebug.Log($"[{Infoholic.ModInitials}] inGame is now true.");
            yield break;
        }

        private IEnumerator GameEnd(IGameModeHandler gameModeHandler)
        {
            inGame = false;

            InfoholicDebug.Log($"[{Infoholic.ModInitials}] inGame is now false.");
            yield break;
        }

        private IEnumerator PickStart(IGameModeHandler gameModeHandler)
        {
            inPick = true;
            inBattle = false;

            if (DisableDuringBattlePhase)
            {
                GameStatusUpdate gameStatusUpdate = new GameObject().AddComponent<GameStatusUpdate>();
            }

            InfoholicDebug.Log($"[{Infoholic.ModInitials}] inPick is now true.");
            yield break;
        }

        private IEnumerator PickEnd(IGameModeHandler gameModeHandler)
        {
            inPick = false;
            inBattle = true;

            if (DisableDuringPickPhase)
            {
                GameStatusUpdate gameStatusUpdate = new GameObject().AddComponent<GameStatusUpdate>();
            }

            InfoholicDebug.Log($"[{Infoholic.ModInitials}] inPick is now false.");
            yield break;
        }


        private void NewGUI(GameObject menu)
        {
            TextMeshProUGUI textMeshProUGUI;
            MenuHandler.CreateText("Infoholic Settings (BETA)", menu, out textMeshProUGUI, 60, true, null, null, null, null);
            GameObject toggle = MenuHandler.CreateToggle(Infoholic.SettingsEnableMod, "<b><color=#09ff00>Enable Mod<b></color>", menu, delegate(bool value)
            {
                if (inGame)
                {
                    GameStatusUpdate gameStatusUpdate = new GameObject().AddComponent<GameStatusUpdate>();
                }

                Infoholic.SettingsEnableMod = value;
            }, 50, true, null, null, null, null);
            GameObject toggle2 = MenuHandler.CreateToggle(Infoholic.DisableDuringPickPhase, "Disable during pick phase", menu, delegate(bool value)
            {
                Infoholic.DisableDuringPickPhase = value;
            }, 50, true, null, null, null, null);
            GameObject toggle3 = MenuHandler.CreateToggle(Infoholic.DisableDuringBattlePhase, "Disable during battle phase", menu, delegate (bool value)
            {
                Infoholic.DisableDuringBattlePhase = value;
            }, 50, true, null, null, null, null);
            Slider opacitySlider;
            MenuHandler.CreateSlider("Text Opacity", menu, 50, 0f, 1f, Infoholic.Opacity, delegate(float value)
            {
                Infoholic.Opacity = value;
            }, out opacitySlider, false, null, Slider.Direction.LeftToRight, true, null, null, null, null);
            Slider fontSizeSlider;
            MenuHandler.CreateSlider("Text Size", menu, 50, 0f, 3f, Infoholic.FontSize, delegate(float value)
            {
                Infoholic.FontSize = value;
            }, out fontSizeSlider, false, null, Slider.Direction.LeftToRight, true, null, null, null, null);
            Slider fontSpacingSlider;
            MenuHandler.CreateSlider("Text Spacing", menu, 50, -1f, 1f, Infoholic.FontSpacing, delegate (float value)
            {
                Infoholic.FontSpacing = value;
            }, out fontSpacingSlider, false, null, Slider.Direction.LeftToRight, true, null, null, null, null);
            Slider textX;
            MenuHandler.CreateSlider("Text X Offset", menu, 50, -10f, 50f, (float)Infoholic.TextX, delegate(float value)
            {
                Infoholic.TextX = (int)value;
            }, out textX, true, null, Slider.Direction.LeftToRight, true, null, null, null, null);
            Slider textY;
            MenuHandler.CreateSlider("Text Y Offset", menu, 50, -10f, 25f, (float)Infoholic.TextY, delegate(float value)
            {
                Infoholic.TextY = (int)value;
            }, out textY, true, null, Slider.Direction.LeftToRight, true, null, null, null, null);
            //MenuHandler.CreateButton("<b><color=#ff0000>Reset</color></b> all settings (reopen menu for preview)", menu, delegate ()
            //{
                //Infoholic.TextX = 0;
                //Infoholic.TextY = 0;
                //Infoholic.Opacity = 0.75f;
                //Infoholic.FontSize = 2f;
                //textX.value = (float)Infoholic.TextX;
                //textY.value = (float)Infoholic.TextY;
                //opacitySlider.value = Infoholic.Opacity;
                //fontSizeSlider.value = Infoholic.FontSize;

                //UnityEngine.Object.Destroy(transform.gameObject);

            //}, 40, true, null, null, null, null);
            MenuHandler.CreateText("<b><color=#ff0000>^^</color></b>(Some of these settings could potentially break your game, requiring a restart.)<b><color=#ff0000>^^</color></b>", menu, out textMeshProUGUI, 20, true, null, null, null, null);
            MenuHandler.CreateText("<b>(PLEASE report all bugs to Penial#3298 on discord!)</b>", menu, out textMeshProUGUI, 20, true, null, null, null, null);
            GameObject toggledebug = MenuHandler.CreateToggle(Infoholic.DebugMode, "<b>DEBUG MODE</b>", menu, delegate (bool value)
            {
                Infoholic.DebugMode = value;
            }, 50, true, null, null, null, null);
            menu.GetComponentInChildren<GoBack>(true).goBackEvent.AddListener(delegate ()
            {
                Infoholic.inSettings = false;
                InfoholicDebug.Log($"[{Infoholic.ModInitials}] MENU CLOSED");
            });
            menu.transform.Find("Group/Back").gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                Infoholic.inSettings = false;
                InfoholicDebug.Log($"[{Infoholic.ModInitials}] MENU CLOSED");
            });
        }

        public static bool SettingsEnableMod
        {
            get
            {
                return PlayerPrefs.GetInt(Infoholic.GetConfigKey("SettingsEnableMod"), 1) == 1;
            }
            set
            {
                PlayerPrefs.SetInt(Infoholic.GetConfigKey("SettingsEnableMod"), value ? 1 : 0);
            }
        }

        public static bool DisableDuringPickPhase
        {
            get
            {
                return PlayerPrefs.GetInt(Infoholic.GetConfigKey("DisableDuringPickPhase"), 0) == 1;
            }
            set
            {
                PlayerPrefs.SetInt(Infoholic.GetConfigKey("DisableDuringPickPhase"), value ? 1 : 0);
            }
        }

        public static bool DisableDuringBattlePhase
        {
            get
            {
                return PlayerPrefs.GetInt(Infoholic.GetConfigKey("DisableDuringBattlePhase"), 0) == 1;
            }
            set
            {
                PlayerPrefs.SetInt(Infoholic.GetConfigKey("DisableDuringBattlePhase"), value ? 1 : 0);
            }
        }

        public static bool DebugMode
        {
            get
            {
                return PlayerPrefs.GetInt(Infoholic.GetConfigKey("DebugMode"), 0) == 1;
            }
            set
            {
                PlayerPrefs.SetInt(Infoholic.GetConfigKey("DebugMode"), value ? 1 : 0);
            }
        }

        public static float Opacity
        {
            get
            {
                return PlayerPrefs.GetFloat(Infoholic.GetConfigKey("opacity"), 0.75f);
            }
            set
            {
                PlayerPrefs.SetFloat(Infoholic.GetConfigKey("opacity"), value);
            }
        }

        public static float FontSize
        {
            get
            {
                return PlayerPrefs.GetFloat(Infoholic.GetConfigKey("fontsize"), 2f);
            }
            set
            {
                PlayerPrefs.SetFloat(Infoholic.GetConfigKey("fontsize"), value);
            }
        }

        public static float FontSpacing
        {
            get
            {
                return PlayerPrefs.GetFloat(Infoholic.GetConfigKey("fontspacing"), 0f);
            }
            set
            {
                PlayerPrefs.SetFloat(Infoholic.GetConfigKey("fontspacing"), value);
            }
        }

        public static int TextX
        {
            get
            {
                return PlayerPrefs.GetInt(Infoholic.GetConfigKey("textx"), 0);
            }
            set
            {
                PlayerPrefs.SetInt(Infoholic.GetConfigKey("textx"), value);
            }
        }

        public static int TextY
        {
            get
            {
                return PlayerPrefs.GetInt(Infoholic.GetConfigKey("texty"), 0);
            }
            set
            {
                PlayerPrefs.SetInt(Infoholic.GetConfigKey("texty"), value);
            }
        }

        private static string GetConfigKey(string key)
        {
            return "IH_" + key;
        }
    }
}