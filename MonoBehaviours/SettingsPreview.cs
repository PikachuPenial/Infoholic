using TMPro;
using UnityEngine;

namespace Infoholic.MonoBehaviours
{
    internal class SettingsPreview : MonoBehaviour
    {

        private static TextMeshProUGUI
            healthText, livesText, blockCooldownText, blockCountText, movementSpeedText, jumpHeightText, playerSizeText,
            damageText, knockbackText, lifeStealText, bulletGrowthText, bulletSlowText, attackSpeedText, projectileSpeedText,
            projectileSimulationSpeedText, reloadTimeText, bulletGravityText, ammoText,
            bulletsText, rangeText, reflectsText, burstsText;

        void Start()
        {
            // Health
            healthText = new GameObject().AddComponent<TextMeshProUGUI>();
            healthText.gameObject.AddComponent<DestroyOnUnparent>();
            healthText.transform.parent = gameObject.transform;
            healthText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            healthText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            healthText.fontSize = Infoholic.FontSize;
            healthText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Lives
            livesText = new GameObject().AddComponent<TextMeshProUGUI>();
            livesText.gameObject.AddComponent<DestroyOnUnparent>();
            livesText.transform.parent = gameObject.transform;
            livesText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            livesText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            livesText.fontSize = Infoholic.FontSize;
            livesText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Block Cooldown
            blockCooldownText = new GameObject().AddComponent<TextMeshProUGUI>();
            blockCooldownText.gameObject.AddComponent<DestroyOnUnparent>();
            blockCooldownText.transform.parent = gameObject.transform;
            blockCooldownText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            blockCooldownText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            blockCooldownText.fontSize = Infoholic.FontSize;
            blockCooldownText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Additional Blocks
            blockCountText = new GameObject().AddComponent<TextMeshProUGUI>();
            blockCountText.gameObject.AddComponent<DestroyOnUnparent>();
            blockCountText.transform.parent = gameObject.transform;
            blockCountText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            blockCountText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            blockCountText.fontSize = Infoholic.FontSize;
            blockCountText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Damage
            damageText = new GameObject().AddComponent<TextMeshProUGUI>();
            damageText.gameObject.AddComponent<DestroyOnUnparent>();
            damageText.transform.parent = gameObject.transform;
            damageText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            damageText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            damageText.fontSize = Infoholic.FontSize;
            damageText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Knockback
            knockbackText = new GameObject().AddComponent<TextMeshProUGUI>();
            knockbackText.gameObject.AddComponent<DestroyOnUnparent>();
            knockbackText.transform.parent = gameObject.transform;
            knockbackText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            knockbackText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            knockbackText.fontSize = Infoholic.FontSize;
            knockbackText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Life Steal
            lifeStealText = new GameObject().AddComponent<TextMeshProUGUI>();
            lifeStealText.gameObject.AddComponent<DestroyOnUnparent>();
            lifeStealText.transform.parent = gameObject.transform;
            lifeStealText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            lifeStealText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            lifeStealText.fontSize = Infoholic.FontSize;
            lifeStealText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bullet Growth
            bulletGrowthText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletGrowthText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletGrowthText.transform.parent = gameObject.transform;
            bulletGrowthText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletGrowthText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            bulletGrowthText.fontSize = Infoholic.FontSize;
            bulletGrowthText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bullet Slow
            bulletSlowText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletSlowText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletSlowText.transform.parent = gameObject.transform;
            bulletSlowText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletSlowText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            bulletSlowText.fontSize = Infoholic.FontSize;
            bulletSlowText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);


            // Movement Speed
            movementSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            movementSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            movementSpeedText.transform.parent = gameObject.transform;
            movementSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            movementSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            movementSpeedText.fontSize = Infoholic.FontSize;
            movementSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Jump Height
            jumpHeightText = new GameObject().AddComponent<TextMeshProUGUI>();
            jumpHeightText.gameObject.AddComponent<DestroyOnUnparent>();
            jumpHeightText.transform.parent = gameObject.transform;
            jumpHeightText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            jumpHeightText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            jumpHeightText.fontSize = Infoholic.FontSize;
            jumpHeightText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Player Size
            playerSizeText = new GameObject().AddComponent<TextMeshProUGUI>();
            playerSizeText.gameObject.AddComponent<DestroyOnUnparent>();
            playerSizeText.transform.parent = gameObject.transform;
            playerSizeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            playerSizeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            playerSizeText.fontSize = Infoholic.FontSize;
            playerSizeText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Attack Speed
            attackSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            attackSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            attackSpeedText.transform.parent = gameObject.transform;
            attackSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            attackSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            attackSpeedText.fontSize = Infoholic.FontSize;
            attackSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Projectile Speed
            projectileSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSpeedText.transform.parent = gameObject.transform;
            projectileSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            projectileSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            projectileSpeedText.fontSize = Infoholic.FontSize;
            projectileSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Projectile Simulation Speed
            projectileSimulationSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSimulationSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSimulationSpeedText.transform.parent = gameObject.transform;
            projectileSimulationSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            projectileSimulationSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            projectileSimulationSpeedText.fontSize = Infoholic.FontSize;
            projectileSimulationSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Reload Time
            reloadTimeText = new GameObject().AddComponent<TextMeshProUGUI>();
            reloadTimeText.gameObject.AddComponent<DestroyOnUnparent>();
            reloadTimeText.transform.parent = gameObject.transform;
            reloadTimeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            reloadTimeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            reloadTimeText.fontSize = Infoholic.FontSize;
            reloadTimeText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bullet Gravity
            bulletGravityText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletGravityText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletGravityText.transform.parent = gameObject.transform;
            bulletGravityText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletGravityText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            bulletGravityText.fontSize = Infoholic.FontSize;
            bulletGravityText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Ammo
            ammoText = new GameObject().AddComponent<TextMeshProUGUI>();
            ammoText.gameObject.AddComponent<DestroyOnUnparent>();
            ammoText.transform.parent = gameObject.transform;
            ammoText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            ammoText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            ammoText.fontSize = Infoholic.FontSize;
            ammoText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bullets
            bulletsText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletsText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletsText.transform.parent = gameObject.transform;
            bulletsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            bulletsText.fontSize = Infoholic.FontSize;
            bulletsText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bullet Range
            rangeText = new GameObject().AddComponent<TextMeshProUGUI>();
            rangeText.gameObject.AddComponent<DestroyOnUnparent>();
            rangeText.transform.parent = gameObject.transform;
            rangeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            rangeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            rangeText.fontSize = Infoholic.FontSize;
            rangeText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Reflects
            reflectsText = new GameObject().AddComponent<TextMeshProUGUI>();
            reflectsText.gameObject.AddComponent<DestroyOnUnparent>();
            reflectsText.transform.parent = gameObject.transform;
            reflectsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            reflectsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            reflectsText.fontSize = Infoholic.FontSize;
            reflectsText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bursts
            burstsText = new GameObject().AddComponent<TextMeshProUGUI>();
            burstsText.gameObject.AddComponent<DestroyOnUnparent>();
            burstsText.transform.parent = gameObject.transform;
            burstsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            burstsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            burstsText.fontSize = Infoholic.FontSize;
            burstsText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            SetTextPosition();
        }

        public void Update()
        {
            if (Infoholic.inSettings)
            {
                healthText.text = "HP: 100 / 100";
                damageText.text = "DMG: 55";
                livesText.text = "Lives: 1";
                blockCooldownText.text = "Block CD: 4.00s";
                blockCountText.text = "Block Count: 1";
                movementSpeedText.text = "Move SPD: 1.00";
                jumpHeightText.text = "Jump Height: 1.00";
                playerSizeText.text = "Player Size: 1.00";
                knockbackText.text = "Knockback: 1.00";
                lifeStealText.text = "Life Steal: 0.00";
                bulletGrowthText.text = "Damage Grow: 0.00";
                bulletSlowText.text = "Bullet Slow: 0.00";
                attackSpeedText.text = "Attack SPD: 0.30s";
                projectileSpeedText.text = "Bullet SPD: 1.00";
                projectileSimulationSpeedText.text = "Projectile SPD: 1.00";
                reloadTimeText.text = "Reload Time: 2.00s";
                bulletGravityText.text = "Bullet Gravity: 1.00";
                ammoText.text = "Ammo: 3";
                bulletsText.text = "Bullets: 1";
                rangeText.text = "Bullet Range: 0";
                reflectsText.text = "Bounces: 0";
                burstsText.text = "Bursts: 0";

                SetTextPosition();
                UpdateTextScale();
            }

            if (Input.GetKeyDown(Infoholic.DetectedKey))
            {
                Toggle();
            }

            if (Infoholic.inGame)
            {
                Destroy(this.gameObject);
            }

            if (!Infoholic.SettingsEnableMod)
            {
                Destroy(this.gameObject);
            }

            if (!Infoholic.inSettings)
            {
                Destroy(this.gameObject);
            }
        }

        private void Toggle()
        {
            if (!Infoholic.previewStatsToggledPressed)
            {
                Infoholic.previewStatsToggledPressed = true;
            }
            else
            {
                Infoholic.previewStatsToggledPressed = false;
            }
        }

        private void SetTextPosition()
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
            else
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
            if (!Infoholic.previewStatsToggledPressed)
            {
                Infoholic.statsToggled = .4f;
            }
            else
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
            else
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
                if (this.gameObject.transform.parent == null)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}