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

        private static TextMeshProUGUI blockCooldownText;

        private static TextMeshProUGUI movementSpeedText;

        private static TextMeshProUGUI damageText;

        private static TextMeshProUGUI attackSpeedText;

        private static TextMeshProUGUI reloadTimeText;

        private static TextMeshProUGUI ammoText;

        private static TextMeshProUGUI bulletsText;

        private static TextMeshProUGUI burstsText;

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
            healthText = new GameObject().AddComponent<TextMeshProUGUI>();
            healthText.gameObject.AddComponent<DestroyOnUnparent>();
            healthText.transform.parent = gameObject.transform;
            healthText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            livesText = new GameObject().AddComponent<TextMeshProUGUI>();
            livesText.gameObject.AddComponent<DestroyOnUnparent>();
            livesText.transform.parent = gameObject.transform;
            livesText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            blockCooldownText = new GameObject().AddComponent<TextMeshProUGUI>();
            blockCooldownText.gameObject.AddComponent<DestroyOnUnparent>();
            blockCooldownText.transform.parent = gameObject.transform;
            blockCooldownText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            damageText = new GameObject().AddComponent<TextMeshProUGUI>();
            damageText.gameObject.AddComponent<DestroyOnUnparent>();
            damageText.transform.parent = gameObject.transform;
            damageText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            movementSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            movementSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            movementSpeedText.transform.parent = gameObject.transform;
            movementSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            attackSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            attackSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            attackSpeedText.transform.parent = gameObject.transform;
            attackSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            reloadTimeText = new GameObject().AddComponent<TextMeshProUGUI>();
            reloadTimeText.gameObject.AddComponent<DestroyOnUnparent>();
            reloadTimeText.transform.parent = gameObject.transform;
            reloadTimeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            ammoText = new GameObject().AddComponent<TextMeshProUGUI>();
            ammoText.gameObject.AddComponent<DestroyOnUnparent>();
            ammoText.transform.parent = gameObject.transform;
            ammoText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            bulletsText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletsText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletsText.transform.parent = gameObject.transform;
            bulletsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            burstsText = new GameObject().AddComponent<TextMeshProUGUI>();
            burstsText.gameObject.AddComponent<DestroyOnUnparent>();
            burstsText.transform.parent = gameObject.transform;
            burstsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            gameObject.transform.position = new Vector3(0f, 0f, 0f);
        }

        public void Update()
        {
            {
                UnityEngine.Debug.Log(movementSpeedText);
                ToggleGameUI.showStats();
                ToggleGameUI.disableStats();
                healthText.text = $"Health: [{player.data.health:f2} / {player.data.maxHealth:f2}]";
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] HEALTH STAT WORKS.");
                healthText.alpha = 1f;
                healthText.fontSize = 2;
                livesText.text = $"Lives: [{player.data.health:f2} / {player.data.stats.respawns:f2}]";
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] LIVES STAT WORKS.");
                livesText.alpha = 1f;
                livesText.fontSize = 2;
                blockCooldownText.text = $"Block Cooldown: [{player.data.health:f2} / {player.data.block.cooldown:f2}]";
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] BLOCK COOLDOWN STAT WORKS.");
                blockCooldownText.alpha = 1f;
                blockCooldownText.fontSize = 2;
                movementSpeedText.text = $"Movement Speed: [{player.data.stats.movementSpeed:f2}]";
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] MOVEMENT SPEED STAT WORKS.");
                movementSpeedText.alpha = 1f;
                movementSpeedText.fontSize = 2;
                damageText.text = $"Damage: [{player.data.weaponHandler.gun.damage:f2}]";
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] DAMAGE STAT WORKS.");
                damageText.alpha = 1f;
                damageText.fontSize = 2;
                attackSpeedText.text = $"Attack Speed: [{player.data.weaponHandler.gun.attackSpeed:f2}]";
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] ATTACK SPEED STAT WORKS.");
                attackSpeedText.alpha = 1f;
                attackSpeedText.fontSize = 2;
                reloadTimeText.text = $"Reload Time: [{player.data.weaponHandler.gun.reloadTime:f2}]";
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] RELOAD TIME STAT WORKS.");
                reloadTimeText.alpha = 1f;
                reloadTimeText.fontSize = 2;
                ammoText.text = $"Ammo: [{player.data.weaponHandler.gun.ammo:f2}]";
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] AMMO STAT WORKS.");
                ammoText.alpha = 1f;
                ammoText.fontSize = 2;
                bulletsText.text = $"Bullets: [{player.data.weaponHandler.gun.projectiles:f2}]";
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] BULLET STAT WORKS.");
                bulletsText.alpha = 1f;
                bulletsText.fontSize = 2;
                burstsText.text = $"Bursts: [{player.data.weaponHandler.gun.bursts:f2}]";
                UnityEngine.Debug.Log($"[{Infoholic.ModInitials}] BURSTS STAT WORKS.");
                burstsText.alpha = 1f;
                burstsText.fontSize = 2;
            }
        }

        public class DestroyOnUnparent : MonoBehaviour
        {
            void LateUpdate()
            {
                if (this.gameObject.transform.parent == null) { Destroy(this.gameObject); }
            }
        }
    }
}