using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using TMPro;
using UnboundLib;
using UnboundLib.GameModes;
using UnboundLib.Utils;
using UnboundLib.Utils.UI;
using Infoholic.MonoBehaviours;
using Infoholic.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Infoholic
{
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("com.penial.rounds.Infoholic", "Infoholic", "2.0.2")]
    [BepInProcess("Rounds.exe")]

    public class Infoholic : BaseUnityPlugin
    {
        public const string AbbrModName = "IH";
        public const string ModInitials = "IH";
        private const string ModId = "com.penial.rounds.Infoholic";
        private const string ModName = "Infoholic";
        public const string Version = "2.0.2";
        private const string CompatibilityModName = "Infoholic";
        public static bool DebugMode = false;

        private static TextMeshProUGUI keyText;
        private static GameObject button;

        public static bool inGame;
        public static bool inPick;
        public static bool inBattle;
        public static bool inSettings;

        private bool detectKey;
        private bool haveDetectedKey;

        public static bool statsToggledPressed;
        public static bool previewStatsToggledPressed;
        public static float statsToggled;

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
            //var plugins = (List<BaseUnityPlugin>)typeof(BepInEx.Bootstrap.Chainloader).GetField("_plugins", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
            //willsWackyCards = plugins.Exists(plugin => plugin.Info.Metadata.GUID == "com.willuwontu.rounds.cards");
            //classesManagerReborn = plugins.Exists(plugin => plugin.Info.Metadata.GUID == "root.classes.manager.reborn");
            //mapEmbiggener = plugins.Exists(plugin => plugin.Info.Metadata.GUID == "pykess.rounds.plugins.mapembiggener");

            //if (mapEmbiggener == true)
            //{
                //InfoholicDebug.Log($"[{Infoholic.ModInitials}] Map Embiggener is enabled, setting up support.");
            //}

            Unbound.RegisterCredits("<color=#09ff00>I</color>nfo<color=#ff0000>h</color>olic", new string[]
            {
                "Penial"
            }, new string[]
            {
                "<b><color=#ff00df>GitHub (Source Code)</b></color>",
                "Penial's Steam Profile",
            }, new string[]
            {
                "https://github.com/PikachuPenial/Infoholic",
                "https://steamcommunity.com/id/penialsteam",
            });

            Unbound.RegisterMenu("Infoholic Settings", delegate ()
            {
                inSettings = true;
                previewStatsToggledPressed = false;
                SettingsPreview settingsPreview = new GameObject().AddComponent<SettingsPreview>();

            }, new Action<GameObject>(this.NewGUI), null, false);

            GameModeManager.AddHook(GameModeHooks.HookGameStart, this.GameStart);
            GameModeManager.AddHook(GameModeHooks.HookGameEnd, this.GameEnd);

            GameModeManager.AddHook(GameModeHooks.HookPickStart, this.PickStart);
            GameModeManager.AddHook(GameModeHooks.HookRoundStart, this.RoundStart);
        }

        //void Update()
        //{
            //if (GameModeManager.CurrentHandlerID == GameModeManager.SandBoxID)
            //{
                //inSandbox = true;
            //}

            //if (inSandbox & !inSandboxStatsSpawned)
            //{
                //GameStatusUpdate gameStatusUpdate = new GameObject().AddComponent<GameStatusUpdate>();
                //inSandboxStatsSpawned = true;
            //}

        //}

        private IEnumerator GameStart(IGameModeHandler gameModeHandler)
        {
            inGame = true;
            statsToggledPressed = false;

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
            inPick = false;
            inBattle = false;

            InfoholicDebug.Log($"[{Infoholic.ModInitials}] inGame is now false.");
            yield break;
        }

        private IEnumerator PickStart(IGameModeHandler gameModeHandler)
        {
            inPick = true;
            inBattle = false;

            if (DisableDuringBattlePhase)
            {
                Infoholic.statsToggledPressed = false;
            }

            if (DisableDuringPickPhase)
            {
                Infoholic.statsToggledPressed = true;
            }

            InfoholicDebug.Log($"[{Infoholic.ModInitials}] inPick is now true.");
            yield break;
        }

        private IEnumerator RoundStart(IGameModeHandler gameModeHandler)
        {
            inBattle = true;
            inPick = false;

            if (DisableDuringPickPhase)
            {
                statsToggledPressed = false;
            }

            if (DisableDuringBattlePhase)
            {
                Infoholic.statsToggledPressed = true;
            }

            InfoholicDebug.Log($"[{Infoholic.ModInitials}] inPick is now true.");
            yield break;
        }

        private void NewGUI(GameObject menu)
        {
            TextMeshProUGUI textMeshProUGUI;
            MenuHandler.CreateText("INFOHOLIC SETTINGS", menu, out textMeshProUGUI, 60, true, null, null, null, null);
            Infoholic.button = MenuHandler.CreateButton("SET TOGGLE KEYBIND", menu, delegate ()
            {
                this.detectKey = true;
            }, 35, true, null, null, null, null);
            MenuHandler.CreateText("CURRENT TOGGLE KEYBIND: ", menu, out Infoholic.keyText, 40, true, null, null, null, null);
            GameObject toggle = MenuHandler.CreateToggle(Infoholic.SettingsEnableMod, "<b><color=#09ff00>Enable</color></b> Mod", menu, delegate(bool value)
            {
                Infoholic.SettingsEnableMod = value;

                if (SettingsEnableMod)
                {
                    SettingsPreview settingsPreview = new GameObject().AddComponent<SettingsPreview>();
                    Infoholic.previewStatsToggledPressed = false;
                    InfoholicDebug.Log($"[{Infoholic.ModInitials}] SETTINGS PREVIEW PULLED UP since you are NOT in game, and are in the settings menu.");
                }
            }, 50, true, null, null, null, null);
            GameObject toggle2 = MenuHandler.CreateToggle(Infoholic.SimpleMode, "<b><color=#00e5ff>Simplistic</color></b> Mode (less stats)", menu, delegate (bool value)
            {
                Infoholic.SimpleMode = value;
            }, 50, true, null, null, null, null);
            GameObject toggle3 = MenuHandler.CreateToggle(Infoholic.DisableDuringPickPhase, "Hide during pick phase", menu, delegate(bool value)
            {
                Infoholic.DisableDuringPickPhase = value;

                if (inPick & DisableDuringPickPhase)
                {
                    Infoholic.statsToggledPressed = true;
                }

                if (inPick & !DisableDuringPickPhase)
                {
                    Infoholic.statsToggledPressed = false;
                }
            }, 50, true, null, null, null, null);
            GameObject toggle4 = MenuHandler.CreateToggle(Infoholic.DisableDuringBattlePhase, "Hide during battle phase", menu, delegate (bool value)
            {
                Infoholic.DisableDuringBattlePhase = value;

                if (inBattle & DisableDuringBattlePhase)
                {
                    Infoholic.statsToggledPressed = true;
                }

                if (inBattle & !DisableDuringBattlePhase)
                {
                    Infoholic.statsToggledPressed = false;
                }
            }, 50, true, null, null, null, null);
            GameObject colorMenu = MenuHandler.CreateMenu("COLOR SETTINGS", () => { }, menu, 35, true, true, menu.transform.parent.gameObject);
            ColorSettingsGUI(colorMenu);
            Slider opacitySlider;
            MenuHandler.CreateSlider("Opacity", menu, 50, 0f, 1f, Infoholic.Opacity, delegate(float value)
            {
                Infoholic.Opacity = value;
            }, out opacitySlider, false, null, Slider.Direction.LeftToRight, true, null, null, null, null);
            Slider fontSizeSlider;
            MenuHandler.CreateSlider("Size", menu, 50, 0f, 5f, Infoholic.FontSize, delegate(float value)
            {
                Infoholic.FontSize = value;
            }, out fontSizeSlider, false, null, Slider.Direction.LeftToRight, true, null, null, null, null);
            Slider fontSpacingSlider;
            MenuHandler.CreateSlider("Spacing", menu, 50, -3f, 2f, Infoholic.FontSpacing, delegate (float value)
            {
                Infoholic.FontSpacing = value;
            }, out fontSpacingSlider, false, null, Slider.Direction.LeftToRight, true, null, null, null, null);
            Slider textX;
            MenuHandler.CreateSlider("X Offset", menu, 50, -75f, 75f, (float)Infoholic.TextX, delegate(float value)
            {
                Infoholic.TextX = (int)value;
            }, out textX, true, null, Slider.Direction.LeftToRight, true, null, null, null, null);
            Slider textY;
            MenuHandler.CreateSlider("Y Offset", menu, 50, -75f, 75f, (float)Infoholic.TextY, delegate(float value)
            {
                Infoholic.TextY = (int)value;
            }, out textY, true, null, Slider.Direction.LeftToRight, true, null, null, null, null);
            MenuHandler.CreateButton("<b><color=#ff0000>Reset</color></b> all settings", menu, delegate ()
            {
                Infoholic.TextX = 0;
                Infoholic.TextY = 0;
                Infoholic.Opacity = 0.75f;
                Infoholic.FontSize = 2f;
                Infoholic.FontSpacing = 0f;
                Infoholic.ColorR = 1f;
                Infoholic.ColorG = 1f;
                Infoholic.ColorB = 1f;
                textX.value = (float)Infoholic.TextX;
                textY.value = (float)Infoholic.TextY;
                opacitySlider.value = Infoholic.Opacity;
                fontSizeSlider.value = Infoholic.FontSize;
                fontSpacingSlider.value = Infoholic.FontSpacing;
            }, 40, true, null, null, null, null);
            menu.GetComponentInChildren<GoBack>(true).goBackEvent.AddListener(delegate ()
            {
                Infoholic.previewStatsToggledPressed = false;
                Infoholic.inSettings = false;
                InfoholicDebug.Log($"[{Infoholic.ModInitials}] MENU CLOSED");
            });
            menu.transform.Find("Group/Back").gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                Infoholic.previewStatsToggledPressed = false;
                Infoholic.inSettings = false;
                InfoholicDebug.Log($"[{Infoholic.ModInitials}] MENU CLOSED");
            });
        }

        private void ColorSettingsGUI(GameObject menu)
        {
            TextMeshProUGUI textMeshProUGUI;
            MenuHandler.CreateText("INFOHOLIC COLOR SETTINGS", menu, out textMeshProUGUI, 60, true, null, null, null, null);

            Slider redSlider;
            Slider blueSlider;
            Slider greenSlider;

            MenuHandler.CreateText("CUSTOM", menu, out textMeshProUGUI, 40, true, null, null, null, null);
            MenuHandler.CreateSlider("RED", menu, 50, 0f, 1f, Infoholic.ColorR, delegate (float value)
            {
                Infoholic.ColorR = value;
            }, out redSlider, false, new Color(1f, 0f, 0f), Slider.Direction.LeftToRight, true, null, null, null, null);

            MenuHandler.CreateSlider("GREEN", menu, 50, 0f, 1f, Infoholic.ColorG, delegate (float value)
            {
                Infoholic.ColorG = value;
            }, out greenSlider, false, new Color(0f, 1f, 0f), Slider.Direction.LeftToRight, true, null, null, null, null);

            MenuHandler.CreateSlider("BLUE", menu, 50, 0f, 1f, Infoholic.ColorB, delegate (float value)
            {
                Infoholic.ColorB = value;
            }, out blueSlider, false, new Color(0f, 0f, 1f), Slider.Direction.LeftToRight, true, null, null, null, null);

            MenuHandler.CreateText("PRESETS", menu, out textMeshProUGUI, 40, true, null, null, null, null);
            MenuHandler.CreateButton("<color=#ffffff>WHITE</color>", menu, delegate ()
            {
                Infoholic.ColorR = 1f;
                Infoholic.ColorG = 1f;
                Infoholic.ColorB = 1f;
                redSlider.value = (float)Infoholic.ColorR;
                greenSlider.value = (float)Infoholic.ColorG;
                blueSlider.value = (float)Infoholic.ColorB;
            }, 30, true, null, null, null, null);

            MenuHandler.CreateButton("<color=#ff0000>RED</color>", menu, delegate ()
            {
                Infoholic.ColorR = 1f;
                Infoholic.ColorG = 0f;
                Infoholic.ColorB = 0f;
                redSlider.value = (float)Infoholic.ColorR;
                greenSlider.value = (float)Infoholic.ColorG;
                blueSlider.value = (float)Infoholic.ColorB;
            }, 30, true, null, null, null, null);

            MenuHandler.CreateButton("<color=#ff8000>ORANGE</color>", menu, delegate ()
            {
                Infoholic.ColorR = 1f;
                Infoholic.ColorG = 0.5f;
                Infoholic.ColorB = 0f;
                redSlider.value = (float)Infoholic.ColorR;
                greenSlider.value = (float)Infoholic.ColorG;
                blueSlider.value = (float)Infoholic.ColorB;
            }, 30, true, null, null, null, null);

            MenuHandler.CreateButton("<color=#ffff00>YELLOW</color>", menu, delegate ()
            {
                Infoholic.ColorR = 1f;
                Infoholic.ColorG = 1f;
                Infoholic.ColorB = 0f;
                redSlider.value = (float)Infoholic.ColorR;
                greenSlider.value = (float)Infoholic.ColorG;
                blueSlider.value = (float)Infoholic.ColorB;
            }, 30, true, null, null, null, null);

            MenuHandler.CreateButton("<color=#00ff00>GREEN</color>", menu, delegate ()
            {
                Infoholic.ColorR = 0f;
                Infoholic.ColorG = 1f;
                Infoholic.ColorB = 0f;
                redSlider.value = (float)Infoholic.ColorR;
                greenSlider.value = (float)Infoholic.ColorG;
                blueSlider.value = (float)Infoholic.ColorB;
            }, 30, true, null, null, null, null);

            MenuHandler.CreateButton("<color=#0000ff>BLUE</color>", menu, delegate ()
            {
                Infoholic.ColorR = 0f;
                Infoholic.ColorG = 0f;
                Infoholic.ColorB = 1f;
                redSlider.value = (float)Infoholic.ColorR;
                greenSlider.value = (float)Infoholic.ColorG;
                blueSlider.value = (float)Infoholic.ColorB;
            }, 30, true, null, null, null, null);

            MenuHandler.CreateButton("<color=#8000ff>PURPLE</color>", menu, delegate ()
            {
                Infoholic.ColorR = 0.5f;
                Infoholic.ColorG = 0f;
                Infoholic.ColorB = 1f;
                redSlider.value = (float)Infoholic.ColorR;
                greenSlider.value = (float)Infoholic.ColorG;
                blueSlider.value = (float)Infoholic.ColorB;
            }, 30, true, null, null, null, null);

            MenuHandler.CreateButton("<color=#ff66b3>PINK</color>", menu, delegate ()
            {
                Infoholic.ColorR = 1f;
                Infoholic.ColorG = 0.4f;
                Infoholic.ColorB = 0.7f;
                redSlider.value = (float)Infoholic.ColorR;
                greenSlider.value = (float)Infoholic.ColorG;
                blueSlider.value = (float)Infoholic.ColorB;
            }, 30, true, null, null, null, null);
        }

        private void Update()
        {
            if (detectKey)
            {
                var values = Enum.GetValues(typeof(KeyCode));
                foreach (KeyCode code in values)
                {
                    if (Input.GetKeyDown(code))
                    {
                        DetectedKey = code;
                        detectKey = false;
                    }
                }

                if (!(button is null)) button.GetComponentInChildren<TextMeshProUGUI>().text = "PRESS ANY KEY...";
                haveDetectedKey = false;
            }
            else if (!haveDetectedKey && !(keyText is null) && !(button is null))
            {
                keyText.text = "CURRENT TOGGLE KEYBIND: " + Enum.GetName(typeof(KeyCode), DetectedKey);
                button.GetComponentInChildren<TextMeshProUGUI>().text = "SET TOGGLE KEYBIND";
                haveDetectedKey = true;
            }

            CheckIfInGame();
        }

        private void CheckIfInGame()
        {
            if (!GameManager.instance.isPlaying && inGame)
            {
                inGame = false;
            }
        }

        public static KeyCode DetectedKey
        {
            get
            {
                return (KeyCode)PlayerPrefs.GetInt(Infoholic.GetConfigKey("keybindcode"), 111);
            }
            set
            {
                PlayerPrefs.SetInt(Infoholic.GetConfigKey("keybindcode"), (int)value);
            }
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

        public static bool SimpleMode
        {
            get
            {
                return PlayerPrefs.GetInt(Infoholic.GetConfigKey("SimpleMode"), 1) == 1;
            }
            set
            {
                PlayerPrefs.SetInt(Infoholic.GetConfigKey("SimpleMode"), value ? 1 : 0);
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

        public static float ColorR
        {
            get
            {
                return PlayerPrefs.GetFloat(Infoholic.GetConfigKey("colorr"), 1f);
            }
            set
            {
                PlayerPrefs.SetFloat(Infoholic.GetConfigKey("colorr"), value);
            }
        }

        public static float ColorG
        {
            get
            {
                return PlayerPrefs.GetFloat(Infoholic.GetConfigKey("colorg"), 1f);
            }
            set
            {
                PlayerPrefs.SetFloat(Infoholic.GetConfigKey("colorg"), value);
            }
        }

        public static float ColorB
        {
            get
            {
                return PlayerPrefs.GetFloat(Infoholic.GetConfigKey("colorb"), 1f);
            }
            set
            {
                PlayerPrefs.SetFloat(Infoholic.GetConfigKey("colorb"), value);
            }
        }

        private static string GetConfigKey(string key)
        {
            return "IH_" + key;
        }
    }
}