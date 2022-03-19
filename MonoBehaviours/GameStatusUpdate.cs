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

        private static TextMeshProUGUI livesText;

        private static TextMeshProUGUI movementSpeedText;

        private static TextMeshProUGUI damageText;

        private static TextMeshProUGUI attackSpeedText;

        private static TextMeshProUGUI reloadTimeText;

        private static TextMeshProUGUI ammoText;

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
            livesText = gameObject.AddComponent<TextMeshProUGUI>();
            damageText = gameObject.AddComponent<TextMeshProUGUI>();
            movementSpeedText = gameObject.AddComponent<TextMeshProUGUI>();
            attackSpeedText = gameObject.AddComponent<TextMeshProUGUI>();
            reloadTimeText = gameObject.AddComponent<TextMeshProUGUI>();
            ammoText = gameObject.AddComponent<TextMeshProUGUI>();
            gameObject.transform.position = new Vector3(0f, 0f, 0f);

            gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
        }

        public void Update()
        {
            {
                ToggleGameUI.showStats();
                ToggleGameUI.disableStats();
                healthText.text = $"Health: [{player.data.health:f2} / {player.data.maxHealth:f2}]";
                healthText.alpha = 1f;
                healthText.fontSize = 2;
                livesText.text = $"Lives: [{player.data.health:f2} / {player.data.stats.respawns:f2}]";
                livesText.alpha = 1f;
                livesText.fontSize = 2;
                movementSpeedText.text = $"Movement Speed: [{player.data.stats.movementSpeed:f2}]";
                movementSpeedText.alpha = 1f;
                movementSpeedText.fontSize = 2;
                damageText.text = $"Damage: [{player.data.weaponHandler.gun.damage:f2}]";
                damageText.alpha = 1f;
                damageText.fontSize = 2;
                attackSpeedText.text = $"Attack Speed: [{player.data.weaponHandler.gun.attackSpeed:f2}]";
                attackSpeedText.alpha = 1f;
                attackSpeedText.fontSize = 2;
                reloadTimeText.text = $"Reload Time: [{player.data.weaponHandler.gun.reloadTime:f2}]";
                reloadTimeText.alpha = 1f;
                reloadTimeText.fontSize = 2;
                ammoText.text = $"Ammo: [{player.data.weaponHandler.gun.ammo:f2}]";
                ammoText.alpha = 1f;
                ammoText.fontSize = 2;
            }
        }
    }
}