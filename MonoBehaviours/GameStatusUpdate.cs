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

        private static TextMeshProUGUI lifeStealText;

        private static TextMeshProUGUI attackSpeedText;

        private static TextMeshProUGUI projectileSpeedText;

        private static TextMeshProUGUI projectileSimulationSpeedText;

        private static TextMeshProUGUI reloadTimeText;

        private static TextMeshProUGUI bulletGravityText;

        private static TextMeshProUGUI ammoText;

        private static TextMeshProUGUI bulletsText;

        private static TextMeshProUGUI reflectsText;

        private static TextMeshProUGUI burstsText;

        private Player player;

        private Gun gun;

        private Block block;

        private Player getLocalPlayer()
        {
            Player player = null;
            PlayerManager.instance.players.ForEach(p => { if (p.data.view.IsMine) player = p; });
            return player;
        }

        private Gun getLocalPlayerGun()
        {
            Gun gun = player.data.weaponHandler.gun;
            return gun;
        }

        private Block getLocalPlayerBlock()
        {
            Block block = player.data.block;
            return block;
        }

        private void Start()
        {
            player = getLocalPlayer();
            gun = getLocalPlayerGun();
            block = getLocalPlayerBlock();

            // Health
            healthText = new GameObject().AddComponent<TextMeshProUGUI>();
            healthText.gameObject.AddComponent<DestroyOnUnparent>();
            healthText.transform.parent = gameObject.transform;
            healthText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            healthText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-14f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            healthText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Lives
            livesText = new GameObject().AddComponent<TextMeshProUGUI>();
            livesText.gameObject.AddComponent<DestroyOnUnparent>();
            livesText.transform.parent = gameObject.transform;
            livesText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            livesText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-15f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            livesText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Block Cooldown
            blockCooldownText = new GameObject().AddComponent<TextMeshProUGUI>();
            blockCooldownText.gameObject.AddComponent<DestroyOnUnparent>();
            blockCooldownText.transform.parent = gameObject.transform;
            blockCooldownText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            blockCooldownText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-16f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            blockCooldownText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Damage
            damageText = new GameObject().AddComponent<TextMeshProUGUI>();
            damageText.gameObject.AddComponent<DestroyOnUnparent>();
            damageText.transform.parent = gameObject.transform;
            damageText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            damageText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-17f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            damageText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Life Steal
            lifeStealText = new GameObject().AddComponent<TextMeshProUGUI>();
            lifeStealText.gameObject.AddComponent<DestroyOnUnparent>();
            lifeStealText.transform.parent = gameObject.transform;
            lifeStealText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            lifeStealText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-18f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            lifeStealText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";


            // Movement Speed
            movementSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            movementSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            movementSpeedText.transform.parent = gameObject.transform;
            movementSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            movementSpeedText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-19f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            movementSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Attack Speed
            attackSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            attackSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            attackSpeedText.transform.parent = gameObject.transform;
            attackSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            attackSpeedText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-20f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            attackSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Projectile Speed
            projectileSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSpeedText.transform.parent = gameObject.transform;
            projectileSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            projectileSpeedText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-21f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            projectileSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Projectile Simulation Speed
            projectileSimulationSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSimulationSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSimulationSpeedText.transform.parent = gameObject.transform;
            projectileSimulationSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            projectileSimulationSpeedText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-22f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            projectileSimulationSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Reload Time
            reloadTimeText = new GameObject().AddComponent<TextMeshProUGUI>();
            reloadTimeText.gameObject.AddComponent<DestroyOnUnparent>();
            reloadTimeText.transform.parent = gameObject.transform;
            reloadTimeText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            reloadTimeText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-23f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            reloadTimeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullet Gravity
            bulletGravityText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletGravityText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletGravityText.transform.parent = gameObject.transform;
            bulletGravityText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            bulletGravityText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-24f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            bulletGravityText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Ammo
            ammoText = new GameObject().AddComponent<TextMeshProUGUI>();
            ammoText.gameObject.AddComponent<DestroyOnUnparent>();
            ammoText.transform.parent = gameObject.transform;
            ammoText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            ammoText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-25f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            ammoText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullets
            bulletsText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletsText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletsText.transform.parent = gameObject.transform;
            bulletsText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            bulletsText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-26f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            bulletsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Reflects
            reflectsText = new GameObject().AddComponent<TextMeshProUGUI>();
            reflectsText.gameObject.AddComponent<DestroyOnUnparent>();
            reflectsText.transform.parent = gameObject.transform;
            reflectsText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            reflectsText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, (-27f + Infoholic.FontSpacing) + Infoholic.TextY, 0f);
            reflectsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bursts
            burstsText = new GameObject().AddComponent<TextMeshProUGUI>();
            burstsText.gameObject.AddComponent<DestroyOnUnparent>();
            burstsText.transform.parent = gameObject.transform;
            burstsText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            burstsText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -28f + Infoholic.TextY, 0f);
            burstsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
        }

        public void Update()
        {
            {
                if (Infoholic.SettingsEnableMod)
                {
                    healthText.text = $"Health: [{player.data.health:f0} / {player.data.maxHealth:f0}]";
                    healthText.alpha = Infoholic.Opacity;
                    healthText.fontSize = Infoholic.FontSize;
                    livesText.text = $"Lives: [{player.data.stats.respawns + 1:f0}]";
                    livesText.alpha = Infoholic.Opacity;
                    livesText.fontSize = Infoholic.FontSize;
                    blockCooldownText.text = $"Block Cooldown: [{block.Cooldown():f2}]";
                    blockCooldownText.alpha = Infoholic.Opacity;
                    blockCooldownText.fontSize = Infoholic.FontSize;
                    movementSpeedText.text = $"Movement Speed: [{player.data.stats.movementSpeed:f2}]";
                    movementSpeedText.alpha = Infoholic.Opacity;
                    movementSpeedText.fontSize = Infoholic.FontSize;
                    damageText.text = $"Damage: [{player.data.weaponHandler.gun.damage * 55f:f2}]";
                    damageText.alpha = Infoholic.Opacity;
                    damageText.fontSize = Infoholic.FontSize;
                    lifeStealText.text = $"Life Steal: [{player.data.stats.lifeSteal:f2}]";
                    lifeStealText.alpha = Infoholic.Opacity;
                    lifeStealText.fontSize = Infoholic.FontSize;
                    attackSpeedText.text = $"Attack Speed: [{(player.data.weaponHandler.gun.attackSpeed * player.data.weaponHandler.gun.attackSpeedMultiplier):f2}]";
                    attackSpeedText.alpha = Infoholic.Opacity;
                    attackSpeedText.fontSize = Infoholic.FontSize;
                    projectileSpeedText.text = $"Bullet Speed: [{player.data.weaponHandler.gun.projectileSpeed:f2}]";
                    projectileSpeedText.alpha = Infoholic.Opacity;
                    projectileSpeedText.fontSize = Infoholic.FontSize;
                    projectileSimulationSpeedText.text = $"Projectile Speed: [{player.data.weaponHandler.gun.projectielSimulatonSpeed:f2}]";
                    projectileSimulationSpeedText.alpha = Infoholic.Opacity;
                    projectileSimulationSpeedText.fontSize = Infoholic.FontSize;
                    reloadTimeText.text = $"Reload Time: [{(gun.GetComponentInChildren<GunAmmo>().reloadTime + gun.GetComponentInChildren<GunAmmo>().reloadTimeAdd) * gun.GetComponentInChildren<GunAmmo>().reloadTimeMultiplier:f2}]";
                    reloadTimeText.alpha = Infoholic.Opacity;
                    reloadTimeText.fontSize = Infoholic.FontSize;
                    bulletGravityText.text = $"Bullet Gravity: [{gun.gravity:f2}]";
                    bulletGravityText.alpha = Infoholic.Opacity;
                    bulletGravityText.fontSize = Infoholic.FontSize;
                    ammoText.text = $"Ammo: [{gun.GetComponentInChildren<GunAmmo>().maxAmmo:f0}]";
                    ammoText.alpha = Infoholic.Opacity;
                    ammoText.fontSize = Infoholic.FontSize;
                    bulletsText.text = $"Bullets: [{gun.numberOfProjectiles:f0}]";
                    bulletsText.alpha = Infoholic.Opacity;
                    bulletsText.fontSize = Infoholic.FontSize;
                    reflectsText.text = $"Bounces: [{gun.reflects:f0}]";
                    reflectsText.alpha = Infoholic.Opacity;
                    reflectsText.fontSize = Infoholic.FontSize;
                    burstsText.text = $"Bursts: [{gun.bursts:f0}]";
                    burstsText.alpha = Infoholic.Opacity;
                    burstsText.fontSize = Infoholic.FontSize;
                }

                if (Infoholic.DisableDuringPickPhase & Infoholic.inPick)
                {
                    Destroy(this.gameObject);
                }

                if (Infoholic.DisableDuringBattlePhase & Infoholic.inBattle)
                {
                    Destroy(this.gameObject);
                }

                if (!Infoholic.SettingsEnableMod)
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

            void DestroyStats()
            {
                Destroy(this.gameObject);
            }
        }
    }
}