using System;
using System.Collections;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using TMPro;
using UnboundLib;
using UnboundLib.GameModes;
using UnboundLib.Utils.UI;
using Infoholic.UI;
using Infoholic.Utilities;
using UnityEngine;

namespace Infoholic.Utilities
{
    public class GameActions
    {

        public static bool inGame;
        public static bool inPick;

        public static IEnumerator GameStart(IGameModeHandler gameModeHandler)
        {
            try
            {
                ToggleGameUI.inGame = true;
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] inGame is now true.");
            }

            yield break;
        }

        public static IEnumerator GameEnd(IGameModeHandler gameModeHandler)
        {
            try
            {
                ToggleGameUI.inGame = false;
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] inGame is now false.");
            }

            yield break;
        }

        public static IEnumerator PickStart(IGameModeHandler gameModeHandler)
        {
            try
            {
                ToggleGameUI.inPick = true;
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] inPick is now true.");
            }

            yield break;
        }

        public static IEnumerator PickEnd(IGameModeHandler gameModeHandler)
        {
            try
            {
                ToggleGameUI.inPick = false;
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] inPIck is now false.");
            }

            yield break;
        }
    }
}
    