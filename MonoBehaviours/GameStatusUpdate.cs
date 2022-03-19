using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using TMPro;
using UnboundLib;
using UnboundLib.GameModes;
using UnboundLib.Utils.UI;
using ModdingUtils;
using ModdingUtils.MonoBehaviours;
using Infoholic.MonoBehaviours;
using Infoholic.Utilities;
using UnityEngine;
using UnityEngine.UI;

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

        private static TextMeshProUGUI projectileSpeedText;

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
            gameObject.transform.position = new Vector3(-2f, -10f, 0f);
            player = getLocalPlayer();

            // Health
            healthText = new GameObject().AddComponent<TextMeshProUGUI>();
            healthText.gameObject.AddComponent<DestroyOnUnparent>();
            healthText.transform.parent = gameObject.transform;
            healthText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            healthText.gameObject.transform.position = new Vector3(6f, -18f, 0f);
            healthText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Lives
            livesText = new GameObject().AddComponent<TextMeshProUGUI>();
            livesText.gameObject.AddComponent<DestroyOnUnparent>();
            livesText.transform.parent = gameObject.transform;
            livesText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            livesText.gameObject.transform.position = new Vector3(6f, -19f, 0f);
            livesText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Block Cooldown
            blockCooldownText = new GameObject().AddComponent<TextMeshProUGUI>();
            blockCooldownText.gameObject.AddComponent<DestroyOnUnparent>();
            blockCooldownText.transform.parent = gameObject.transform;
            blockCooldownText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            blockCooldownText.gameObject.transform.position = new Vector3(6f, -20f, 0f);
            blockCooldownText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Damage
            damageText = new GameObject().AddComponent<TextMeshProUGUI>();
            damageText.gameObject.AddComponent<DestroyOnUnparent>();
            damageText.transform.parent = gameObject.transform;
            damageText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            damageText.gameObject.transform.position = new Vector3(6f, -21f, 0f);
            damageText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";


            // Movement Speed
            movementSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            movementSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            movementSpeedText.transform.parent = gameObject.transform;
            movementSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            movementSpeedText.gameObject.transform.position = new Vector3(6f, -22f, 0f);
            movementSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Attack Speed
            attackSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            attackSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            attackSpeedText.transform.parent = gameObject.transform;
            attackSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            attackSpeedText.gameObject.transform.position = new Vector3(6f, -23f, 0f);
            attackSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Projectile Speed
            projectileSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSpeedText.transform.parent = gameObject.transform;
            projectileSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            projectileSpeedText.gameObject.transform.position = new Vector3(6f, -24f, 0f);
            projectileSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Reload Time
            reloadTimeText = new GameObject().AddComponent<TextMeshProUGUI>();
            reloadTimeText.gameObject.AddComponent<DestroyOnUnparent>();
            reloadTimeText.transform.parent = gameObject.transform;
            reloadTimeText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            reloadTimeText.gameObject.transform.position = new Vector3(6f, -25f, 0f);
            reloadTimeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Ammo
            ammoText = new GameObject().AddComponent<TextMeshProUGUI>();
            ammoText.gameObject.AddComponent<DestroyOnUnparent>();
            ammoText.transform.parent = gameObject.transform;
            ammoText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            ammoText.gameObject.transform.position = new Vector3(6f, -26f, 0f);
            ammoText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullets
            bulletsText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletsText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletsText.transform.parent = gameObject.transform;
            bulletsText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            bulletsText.gameObject.transform.position = new Vector3(6f, -27f, 0f);
            bulletsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bursts
            burstsText = new GameObject().AddComponent<TextMeshProUGUI>();
            burstsText.gameObject.AddComponent<DestroyOnUnparent>();
            burstsText.transform.parent = gameObject.transform;
            burstsText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            burstsText.gameObject.transform.position = new Vector3(6f, -28f, 0f);
            burstsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
        }

        public void Update()
        {
            {
                if (Infoholic.settingsEnableMod)
                {
                    healthText.text = $"Health: [{player.data.health:f0} / {player.data.maxHealth:f0}]";
                    healthText.alpha = 1f;
                    healthText.fontSize = 2;
                    livesText.text = $"Lives: [{player.data.stats.respawns:f0}]";
                    livesText.alpha = 1f;
                    livesText.fontSize = 2;
                    blockCooldownText.text = $"Block Cooldown: [{player.data.block.cooldown:f2}]";
                    blockCooldownText.alpha = 1f;
                    blockCooldownText.fontSize = 2;
                    movementSpeedText.text = $"Movement Speed: [{player.data.stats.movementSpeed:f2}]";
                    movementSpeedText.alpha = 1f;
                    movementSpeedText.fontSize = 2;
                    damageText.text = $"Damage: [{player.data.weaponHandler.gun.damage * 55f:f2}]";
                    damageText.alpha = 1f;
                    damageText.fontSize = 2;
                    attackSpeedText.text = $"Attack Speed: [{(player.data.weaponHandler.gun.attackSpeed * player.data.weaponHandler.gun.attackSpeedMultiplier):f2}]";
                    attackSpeedText.alpha = 1f;
                    attackSpeedText.fontSize = 2;
                    projectileSpeedText.text = $"Projectile Speed: [{(player.data.weaponHandler.gun.projectileSpeed * player.data.weaponHandler.gun.projectielSimulatonSpeed):f2}]";
                    projectileSpeedText.alpha = 1f;
                    projectileSpeedText.fontSize = 2;
                    reloadTimeText.text = $"Reload Time: [{(player.data.weaponHandler.gun.reloadTime + player.data.weaponHandler.gun.reloadTimeAdd):f2}]";
                    reloadTimeText.alpha = 1f;
                    reloadTimeText.fontSize = 2;
                    ammoText.text = $"Ammo: [{player.data.weaponHandler.gun.ammo:f0}]";
                    ammoText.alpha = 1f;
                    ammoText.fontSize = 2;
                    bulletsText.text = $"Bullets: [{player.data.weaponHandler.gun.numberOfProjectiles:f0}]";
                    bulletsText.alpha = 1f;
                    bulletsText.fontSize = 2;
                    burstsText.text = $"Bursts: [{player.data.weaponHandler.gun.bursts:f0}]";
                    burstsText.alpha = 1f;
                    burstsText.fontSize = 2;
                }

                if (!Infoholic.settingsEnableMod)
                {
                    Destroy(this.gameObject);
                }
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