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

namespace Infoholic.UI
{
    public class ToggleGameUI
    {

        public static bool inGame;

        internal static void Initialize()
        {

        }

        public static void showStats()
        {
            if (inGame)
            {

            }
        }

        public static void disableStats()
        {
            if (!inGame)
            {

            }
        }
    }
}