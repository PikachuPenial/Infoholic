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
using UnityEngine;

namespace Infoholic.MonoBehaviours
{
    internal class GameStatusUpdate : MonoBehaviour
    {

        private static TextMeshProUGUI healthText;

        private static Player player;

        private Player getLocalPlayer()
        {
            Player player = null;
            PlayerManager.instance.players.ForEach(p => { if (p.data.view.IsMine) player = p; });
            return player;
        }

        private void Start()
        {
            player = getLocalPlayer();
            healthText = gameObject.AddComponent<TextMeshProUGUI>();
            gameObject.transform.position = new Vector3(0f, 0f, 0f);
        }

        public void Update()
        {
            {
                ToggleGameUI.showStats();
                ToggleGameUI.disableStats();
                healthText.text = $"Health: [{player.data.health:f2} / {player.data.maxHealth:f2}]";
                healthText.alpha = 1f;
                healthText.fontSize = 50;
            }
        }
    }
}