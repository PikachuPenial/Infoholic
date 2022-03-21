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
    internal class SettingsPreview : MonoBehaviour
    {

        private static TextMeshProUGUI
            healthText, livesText, blockCooldownText, movementSpeedText, jumpHeightText,
            damageText, lifeStealText, bulletSlowText, attackSpeedText, projectileSpeedText,
            projectileSimulationSpeedText, reloadTimeText, bulletGravityText, ammoText,
            bulletsText, rangeText, reflectsText, burstsText;

        private void Start()
        {
            // Health
            healthText = new GameObject().AddComponent<TextMeshProUGUI>();
            healthText.gameObject.AddComponent<DestroyOnUnparent>();
            healthText.transform.parent = gameObject.transform;
            healthText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            healthText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Lives
            livesText = new GameObject().AddComponent<TextMeshProUGUI>();
            livesText.gameObject.AddComponent<DestroyOnUnparent>();
            livesText.transform.parent = gameObject.transform;
            livesText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            livesText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Block Cooldown
            blockCooldownText = new GameObject().AddComponent<TextMeshProUGUI>();
            blockCooldownText.gameObject.AddComponent<DestroyOnUnparent>();
            blockCooldownText.transform.parent = gameObject.transform;
            blockCooldownText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            blockCooldownText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Damage
            damageText = new GameObject().AddComponent<TextMeshProUGUI>();
            damageText.gameObject.AddComponent<DestroyOnUnparent>();
            damageText.transform.parent = gameObject.transform;
            damageText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            damageText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Life Steal
            lifeStealText = new GameObject().AddComponent<TextMeshProUGUI>();
            lifeStealText.gameObject.AddComponent<DestroyOnUnparent>();
            lifeStealText.transform.parent = gameObject.transform;
            lifeStealText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            lifeStealText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullet Slow
            bulletSlowText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletSlowText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletSlowText.transform.parent = gameObject.transform;
            bulletSlowText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            bulletSlowText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";


            // Movement Speed
            movementSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            movementSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            movementSpeedText.transform.parent = gameObject.transform;
            movementSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            movementSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Jump Height
            jumpHeightText = new GameObject().AddComponent<TextMeshProUGUI>();
            jumpHeightText.gameObject.AddComponent<DestroyOnUnparent>();
            jumpHeightText.transform.parent = gameObject.transform;
            jumpHeightText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            jumpHeightText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Attack Speed
            attackSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            attackSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            attackSpeedText.transform.parent = gameObject.transform;
            attackSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            attackSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Projectile Speed
            projectileSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSpeedText.transform.parent = gameObject.transform;
            projectileSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            projectileSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Projectile Simulation Speed
            projectileSimulationSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSimulationSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSimulationSpeedText.transform.parent = gameObject.transform;
            projectileSimulationSpeedText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            projectileSimulationSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Reload Time
            reloadTimeText = new GameObject().AddComponent<TextMeshProUGUI>();
            reloadTimeText.gameObject.AddComponent<DestroyOnUnparent>();
            reloadTimeText.transform.parent = gameObject.transform;
            reloadTimeText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            reloadTimeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullet Gravity
            bulletGravityText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletGravityText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletGravityText.transform.parent = gameObject.transform;
            bulletGravityText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            bulletGravityText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Ammo
            ammoText = new GameObject().AddComponent<TextMeshProUGUI>();
            ammoText.gameObject.AddComponent<DestroyOnUnparent>();
            ammoText.transform.parent = gameObject.transform;
            ammoText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            ammoText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullets
            bulletsText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletsText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletsText.transform.parent = gameObject.transform;
            bulletsText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            bulletsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bullet Range
            rangeText = new GameObject().AddComponent<TextMeshProUGUI>();
            rangeText.gameObject.AddComponent<DestroyOnUnparent>();
            rangeText.transform.parent = gameObject.transform;
            rangeText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            rangeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Reflects
            reflectsText = new GameObject().AddComponent<TextMeshProUGUI>();
            reflectsText.gameObject.AddComponent<DestroyOnUnparent>();
            reflectsText.transform.parent = gameObject.transform;
            reflectsText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            reflectsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            // Bursts
            burstsText = new GameObject().AddComponent<TextMeshProUGUI>();
            burstsText.gameObject.AddComponent<DestroyOnUnparent>();
            burstsText.transform.parent = gameObject.transform;
            burstsText.gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            burstsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";

            UpdateTextPosition();
        }

        public void Update()
        {
            {

                if (Infoholic.inSettings)
                {
                    healthText.text = "Health: 100/100";
                    healthText.alpha = Infoholic.Opacity;
                    healthText.fontSize = Infoholic.FontSize;
                    livesText.text = "Lives: 1";
                    livesText.alpha = Infoholic.Opacity;
                    livesText.fontSize = Infoholic.FontSize;
                    blockCooldownText.text = "Block Cooldown: 4.00";
                    blockCooldownText.alpha = Infoholic.Opacity;
                    blockCooldownText.fontSize = Infoholic.FontSize;
                    movementSpeedText.text = "Movement Speed: 1.00";
                    movementSpeedText.alpha = Infoholic.Opacity;
                    movementSpeedText.fontSize = Infoholic.FontSize;
                    jumpHeightText.text = "Jump Height: 1.00";
                    jumpHeightText.alpha = Infoholic.Opacity;
                    jumpHeightText.fontSize = Infoholic.FontSize;
                    damageText.text = "Damage: 55";
                    damageText.alpha = Infoholic.Opacity;
                    damageText.fontSize = Infoholic.FontSize;
                    lifeStealText.text = $"Life Steal: 0.00";
                    lifeStealText.alpha = Infoholic.Opacity;
                    lifeStealText.fontSize = Infoholic.FontSize;
                    bulletSlowText.text = "Bullet Slow: 0.00";
                    bulletSlowText.alpha = Infoholic.Opacity;
                    bulletSlowText.fontSize = Infoholic.FontSize;
                    attackSpeedText.text = "Attack Speed: 0.30";
                    attackSpeedText.alpha = Infoholic.Opacity;
                    attackSpeedText.fontSize = Infoholic.FontSize;
                    projectileSpeedText.text = "Bullet Speed: 1.00";
                    projectileSpeedText.alpha = Infoholic.Opacity;
                    projectileSpeedText.fontSize = Infoholic.FontSize;
                    projectileSimulationSpeedText.text = "Projectile Speed: 1.00";
                    projectileSimulationSpeedText.alpha = Infoholic.Opacity;
                    projectileSimulationSpeedText.fontSize = Infoholic.FontSize;
                    reloadTimeText.text = "Reload Time: 2.00";
                    reloadTimeText.alpha = Infoholic.Opacity;
                    reloadTimeText.fontSize = Infoholic.FontSize;
                    bulletGravityText.text = "Bullet Gravity: 1.00";
                    bulletGravityText.alpha = Infoholic.Opacity;
                    bulletGravityText.fontSize = Infoholic.FontSize;
                    ammoText.text = "Ammo: 3";
                    ammoText.alpha = Infoholic.Opacity;
                    ammoText.fontSize = Infoholic.FontSize;
                    bulletsText.text = "Bullets: 1";
                    bulletsText.alpha = Infoholic.Opacity;
                    bulletsText.fontSize = Infoholic.FontSize;
                    rangeText.text = "Bullet Range: 0";
                    rangeText.alpha = Infoholic.Opacity;
                    rangeText.fontSize = Infoholic.FontSize;
                    reflectsText.text = "Bounces: 0";
                    reflectsText.alpha = Infoholic.Opacity;
                    reflectsText.fontSize = Infoholic.FontSize;
                    burstsText.text = "Bursts: 0";
                    burstsText.alpha = Infoholic.Opacity;
                    burstsText.fontSize = Infoholic.FontSize;

                    UpdateTextPosition();
                }

                if (!Infoholic.inSettings)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        private void UpdateTextPosition()
        {
            healthText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -12f + Infoholic.TextY + (Infoholic.FontSpacing * 17), 0f);

            livesText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -13f + Infoholic.TextY + (Infoholic.FontSpacing * 16), 0f);

            blockCooldownText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -14f + Infoholic.TextY + (Infoholic.FontSpacing * 15), 0f);

            damageText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -15f + Infoholic.TextY + (Infoholic.FontSpacing * 14), 0f);

            lifeStealText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -16f + Infoholic.TextY + (Infoholic.FontSpacing * 13), 0f);

            bulletSlowText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -17f + Infoholic.TextY + (Infoholic.FontSpacing * 12), 0f);

            movementSpeedText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -18f + Infoholic.TextY + (Infoholic.FontSpacing * 11), 0f);

            jumpHeightText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -19f + Infoholic.TextY + (Infoholic.FontSpacing * 10), 0f);

            attackSpeedText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -20f + Infoholic.TextY + (Infoholic.FontSpacing * 9), 0f);

            projectileSpeedText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -21f + Infoholic.TextY + (Infoholic.FontSpacing * 8), 0f);

            projectileSimulationSpeedText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -22f + Infoholic.TextY + (Infoholic.FontSpacing * 7), 0f);

            reloadTimeText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -23f + Infoholic.TextY + (Infoholic.FontSpacing * 6), 0f);

            bulletGravityText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -24f + Infoholic.TextY + (Infoholic.FontSpacing * 5), 0f);

            ammoText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -25f + Infoholic.TextY + (Infoholic.FontSpacing * 4), 0f);

            bulletsText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -26f + Infoholic.TextY + (Infoholic.FontSpacing * 3), 0f);

            rangeText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -27f + Infoholic.TextY + (Infoholic.FontSpacing * 2), 0f);

            reflectsText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -28f + Infoholic.TextY + (Infoholic.FontSpacing * 1), 0f);

            burstsText.gameObject.transform.position = new Vector3(5f + Infoholic.TextX, -29f + Infoholic.TextY, 0f);
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