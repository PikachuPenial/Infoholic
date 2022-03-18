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

namespace Infoholic.UI
{
    public class ToggleGameUI
    {

        public static bool inGame;
        public static bool inPick;

        internal static void Initialize()
        {

        }

        public static void showStats()
        {
            if (inGame)
            {
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] SHOW STATS (game started).");
            }

            while (inGame)
            {
                if (!inPick)
                {
                    UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] SHOW STATS (pick ended).");
                }
            } 
        }

        public static void disableStats()
        {
            if (!inGame)
            {
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] HIDE STATS (game ended).");
            }

            while (inGame)
            {
                if (inPick)
                {
                    UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] HIDE STATS (pick started).");
                }
            }
        }
    }
}