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
        private static TextMeshProUGUI
            healthText, livesText, blockCooldownText, blockCountText, movementSpeedText, jumpHeightText, playerSizeText,
            damageText, knockbackText, lifeStealText, bulletGrowthText, bulletSlowText, attackSpeedText, projectileSpeedText,
            projectileSimulationSpeedText, reloadTimeText, bulletGravityText, ammoText,
            bulletsText, rangeText, reflectsText, burstsText;

        private Player player;
        private Gun gun;
        private Block block;

        private Player getLocalPlayer()
        {
            Player player = null;
            PlayerManager.instance.players.ForEach(p => { if (p.data.view.IsMine && !p.GetComponent<PlayerAPI>().enabled) player = p; });
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
            healthText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            healthText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Lives
            livesText = new GameObject().AddComponent<TextMeshProUGUI>();
            livesText.gameObject.AddComponent<DestroyOnUnparent>();
            livesText.transform.parent = gameObject.transform;
            livesText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            livesText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Block Cooldown
            blockCooldownText = new GameObject().AddComponent<TextMeshProUGUI>();
            blockCooldownText.gameObject.AddComponent<DestroyOnUnparent>();
            blockCooldownText.transform.parent = gameObject.transform;
            blockCooldownText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            blockCooldownText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Additional Blocks
            blockCountText = new GameObject().AddComponent<TextMeshProUGUI>();
            blockCountText.gameObject.AddComponent<DestroyOnUnparent>();
            blockCountText.transform.parent = gameObject.transform;
            blockCountText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            blockCountText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Damage
            damageText = new GameObject().AddComponent<TextMeshProUGUI>();
            damageText.gameObject.AddComponent<DestroyOnUnparent>();
            damageText.transform.parent = gameObject.transform;
            damageText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            damageText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Knockback
            knockbackText = new GameObject().AddComponent<TextMeshProUGUI>();
            knockbackText.gameObject.AddComponent<DestroyOnUnparent>();
            knockbackText.transform.parent = gameObject.transform;
            knockbackText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            knockbackText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Life Steal
            lifeStealText = new GameObject().AddComponent<TextMeshProUGUI>();
            lifeStealText.gameObject.AddComponent<DestroyOnUnparent>();
            lifeStealText.transform.parent = gameObject.transform;
            lifeStealText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            lifeStealText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullet Growth
            bulletGrowthText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletGrowthText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletGrowthText.transform.parent = gameObject.transform;
            bulletGrowthText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletGrowthText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullet Slow
            bulletSlowText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletSlowText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletSlowText.transform.parent = gameObject.transform;
            bulletSlowText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletSlowText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";


            // Movement Speed
            movementSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            movementSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            movementSpeedText.transform.parent = gameObject.transform;
            movementSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            movementSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Jump Height
            jumpHeightText = new GameObject().AddComponent<TextMeshProUGUI>();
            jumpHeightText.gameObject.AddComponent<DestroyOnUnparent>();
            jumpHeightText.transform.parent = gameObject.transform;
            jumpHeightText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            jumpHeightText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Player Size
            playerSizeText = new GameObject().AddComponent<TextMeshProUGUI>();
            playerSizeText.gameObject.AddComponent<DestroyOnUnparent>();
            playerSizeText.transform.parent = gameObject.transform;
            playerSizeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            playerSizeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Attack Speed
            attackSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            attackSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            attackSpeedText.transform.parent = gameObject.transform;
            attackSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            attackSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Projectile Speed
            projectileSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSpeedText.transform.parent = gameObject.transform;
            projectileSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            projectileSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Projectile Simulation Speed
            projectileSimulationSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSimulationSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSimulationSpeedText.transform.parent = gameObject.transform;
            projectileSimulationSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            projectileSimulationSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Reload Time
            reloadTimeText = new GameObject().AddComponent<TextMeshProUGUI>();
            reloadTimeText.gameObject.AddComponent<DestroyOnUnparent>();
            reloadTimeText.transform.parent = gameObject.transform;
            reloadTimeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            reloadTimeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullet Gravity
            bulletGravityText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletGravityText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletGravityText.transform.parent = gameObject.transform;
            bulletGravityText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletGravityText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Ammo
            ammoText = new GameObject().AddComponent<TextMeshProUGUI>();
            ammoText.gameObject.AddComponent<DestroyOnUnparent>();
            ammoText.transform.parent = gameObject.transform;
            ammoText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            ammoText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullets
            bulletsText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletsText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletsText.transform.parent = gameObject.transform;
            bulletsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullet Range
            rangeText = new GameObject().AddComponent<TextMeshProUGUI>();
            rangeText.gameObject.AddComponent<DestroyOnUnparent>();
            rangeText.transform.parent = gameObject.transform;
            rangeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            rangeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Reflects
            reflectsText = new GameObject().AddComponent<TextMeshProUGUI>();
            reflectsText.gameObject.AddComponent<DestroyOnUnparent>();
            reflectsText.transform.parent = gameObject.transform;
            reflectsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            reflectsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bursts
            burstsText = new GameObject().AddComponent<TextMeshProUGUI>();
            burstsText.gameObject.AddComponent<DestroyOnUnparent>();
            burstsText.transform.parent = gameObject.transform;
            burstsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            burstsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            UpdateTextPosition();
        }

        public void Update()
        {
            {
                if (Infoholic.SettingsEnableMod)
                {
                    healthText.text = $"HP: {player.data.health:f0} / {player.data.maxHealth:f0}";
                    healthText.fontSize = Infoholic.FontSize;
                    healthText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    damageText.text = $"DMG: {(gun.damage * 55f) * gun.bulletDamageMultiplier:f0}";
                    damageText.fontSize = Infoholic.FontSize;
                    damageText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    livesText.text = $"Lives: {player.data.stats.respawns + 1:f0}";
                    livesText.fontSize = Infoholic.FontSize;
                    livesText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    blockCooldownText.text = $"Block CD: {block.Cooldown():f2}s";
                    blockCooldownText.fontSize = Infoholic.FontSize;
                    blockCooldownText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    blockCountText.text = $"Block Count: {block.additionalBlocks + 1:f0}";
                    blockCountText.fontSize = Infoholic.FontSize;
                    blockCountText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    movementSpeedText.text = $"Move SPD: {player.data.stats.movementSpeed:f2}";
                    movementSpeedText.fontSize = Infoholic.FontSize;
                    movementSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    jumpHeightText.text = $"Jump Height: {player.data.stats.jump:f2}";
                    jumpHeightText.fontSize = Infoholic.FontSize;
                    jumpHeightText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    playerSizeText.text = $"Player Size: {player.data.stats.sizeMultiplier:f2}";
                    playerSizeText.fontSize = Infoholic.FontSize;
                    playerSizeText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    knockbackText.text = $"Knockback: {gun.knockback:f2}";
                    knockbackText.fontSize = Infoholic.FontSize;
                    knockbackText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    lifeStealText.text = $"Life Steal: {player.data.stats.lifeSteal:f2}";
                    lifeStealText.fontSize = Infoholic.FontSize;
                    lifeStealText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    bulletGrowthText.text = $"Damage Grow: {gun.damageAfterDistanceMultiplier:f2}";
                    bulletGrowthText.fontSize = Infoholic.FontSize;
                    bulletGrowthText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    bulletSlowText.text = $"Bullet Slow: {gun.slow:f2}";
                    bulletSlowText.fontSize = Infoholic.FontSize;
                    bulletSlowText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    attackSpeedText.text = $"Attack SPD: {(gun.attackSpeed * gun.attackSpeedMultiplier):f2}s";
                    attackSpeedText.fontSize = Infoholic.FontSize;
                    attackSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    projectileSpeedText.text = $"Bullet SPD: {gun.projectileSpeed:f2}";
                    projectileSpeedText.fontSize = Infoholic.FontSize;
                    projectileSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    projectileSimulationSpeedText.text = $"Projectile SPD: {gun.projectielSimulatonSpeed:f2}";
                    projectileSimulationSpeedText.fontSize = Infoholic.FontSize;
                    projectileSimulationSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    reloadTimeText.text = $"Reload Time: {(gun.GetComponentInChildren<GunAmmo>().reloadTime + gun.GetComponentInChildren<GunAmmo>().reloadTimeAdd) * gun.GetComponentInChildren<GunAmmo>().reloadTimeMultiplier:f2}s";
                    reloadTimeText.fontSize = Infoholic.FontSize;
                    reloadTimeText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    bulletGravityText.text = $"Bullet Gravity: {gun.gravity:f2}";
                    bulletGravityText.fontSize = Infoholic.FontSize;
                    bulletGravityText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    ammoText.text = $"Ammo: {gun.GetComponentInChildren<GunAmmo>().maxAmmo:f0}";
                    ammoText.fontSize = Infoholic.FontSize;
                    ammoText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    bulletsText.text = $"Bullets: {gun.numberOfProjectiles:f0}";
                    bulletsText.fontSize = Infoholic.FontSize;
                    bulletsText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    rangeText.text = $"Bullet Range: {gun.destroyBulletAfter:f2}";
                    rangeText.fontSize = Infoholic.FontSize;
                    rangeText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    reflectsText.text = $"Bounces: {gun.reflects:f0}";
                    reflectsText.fontSize = Infoholic.FontSize;
                    reflectsText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);
                    burstsText.text = $"Bursts: {gun.bursts:f0}";
                    burstsText.fontSize = Infoholic.FontSize;
                    burstsText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

                    UpdateTextPosition();
                    UpdateTextScale();
                }

                if (Input.GetKeyDown(Infoholic.DetectedKey))
                {
                    ToggleOn();
                }

                if (!Infoholic.inGame)
                {
                    Destroy(this.gameObject);
                }

                if (!Infoholic.SettingsEnableMod)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        private void ToggleOn()
        {
            if (!Infoholic.statsToggledPressed)
            {
                Infoholic.statsToggledPressed = true;
            }
            else
            {
                ToggleOff();
            }
        }

        private void ToggleOff()
        {
            if (Infoholic.statsToggledPressed)
            {
                Infoholic.statsToggledPressed = false;
            }
        }

        private void UpdateTextPosition()
        {
            if (Infoholic.SimpleMode)
            {
                healthText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -22f + Infoholic.TextY + (Infoholic.FontSpacing * 6), 0f);

                damageText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -23f + Infoholic.TextY + (Infoholic.FontSpacing * 5), 0f);

                blockCooldownText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -24f + Infoholic.TextY + (Infoholic.FontSpacing * 4), 0f);

                movementSpeedText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -25f + Infoholic.TextY + (Infoholic.FontSpacing * 3), 0f);

                attackSpeedText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -26f + Infoholic.TextY + (Infoholic.FontSpacing * 2), 0f);

                projectileSpeedText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -27f + Infoholic.TextY + (Infoholic.FontSpacing * 2), 0f);

                projectileSimulationSpeedText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -28f + Infoholic.TextY + (Infoholic.FontSpacing * 1), 0f);

                reloadTimeText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -29f + Infoholic.TextY, 0f);
            }

            if (!Infoholic.SimpleMode)
            {
                healthText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -8f + Infoholic.TextY + (Infoholic.FontSpacing * 21), 0f);

                damageText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -9f + Infoholic.TextY + (Infoholic.FontSpacing * 20), 0f);

                livesText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -10f + Infoholic.TextY + (Infoholic.FontSpacing * 19), 0f);

                blockCooldownText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -11f + Infoholic.TextY + (Infoholic.FontSpacing * 18), 0f);

                blockCountText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -12f + Infoholic.TextY + (Infoholic.FontSpacing * 17), 0f);

                knockbackText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -13f + Infoholic.TextY + (Infoholic.FontSpacing * 16), 0f);

                lifeStealText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -14f + Infoholic.TextY + (Infoholic.FontSpacing * 15), 0f);

                bulletGrowthText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -15f + Infoholic.TextY + (Infoholic.FontSpacing * 14), 0f);

                bulletSlowText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -16f + Infoholic.TextY + (Infoholic.FontSpacing * 13), 0f);

                movementSpeedText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -17f + Infoholic.TextY + (Infoholic.FontSpacing * 12), 0f);

                jumpHeightText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -18f + Infoholic.TextY + (Infoholic.FontSpacing * 11), 0f);

                playerSizeText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -19f + Infoholic.TextY + (Infoholic.FontSpacing * 10), 0f);

                attackSpeedText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -20f + Infoholic.TextY + (Infoholic.FontSpacing * 9), 0f);

                projectileSpeedText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -21f + Infoholic.TextY + (Infoholic.FontSpacing * 8), 0f);

                projectileSimulationSpeedText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -22f + Infoholic.TextY + (Infoholic.FontSpacing * 7), 0f);

                reloadTimeText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -23f + Infoholic.TextY + (Infoholic.FontSpacing * 6), 0f);

                bulletGravityText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -24f + Infoholic.TextY + (Infoholic.FontSpacing * 5), 0f);

                ammoText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -25f + Infoholic.TextY + (Infoholic.FontSpacing * 4), 0f);

                bulletsText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -26f + Infoholic.TextY + (Infoholic.FontSpacing * 3), 0f);

                rangeText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -27f + Infoholic.TextY + (Infoholic.FontSpacing * 2), 0f);

                reflectsText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -28f + Infoholic.TextY + (Infoholic.FontSpacing * 1), 0f);

                burstsText.gameObject.transform.position = new Vector3(4.6f + Infoholic.TextX, -29f + Infoholic.TextY, 0f);
            }
        }

        private void UpdateTextScale()
        {
            if (!Infoholic.statsToggledPressed)
            {
                Infoholic.statsToggled = .4f;
            }

            if (Infoholic.statsToggledPressed)
            {
                Infoholic.statsToggled = 0f;
            }

            if (Infoholic.SimpleMode)
            {
                healthText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                damageText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                livesText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                blockCooldownText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                blockCountText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                knockbackText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                lifeStealText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                bulletGrowthText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                bulletSlowText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                movementSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                jumpHeightText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                playerSizeText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                attackSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                projectileSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                projectileSimulationSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                reloadTimeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                bulletGravityText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                ammoText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                bulletsText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                rangeText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                reflectsText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                burstsText.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
            }

            if (!Infoholic.SimpleMode)
            {
                healthText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                damageText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                livesText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                blockCooldownText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                blockCountText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                knockbackText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                lifeStealText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                bulletGrowthText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                bulletSlowText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                movementSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                jumpHeightText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                playerSizeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                attackSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                projectileSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                projectileSimulationSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                reloadTimeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                bulletGravityText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                ammoText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                bulletsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                rangeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                reflectsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);

                burstsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
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
