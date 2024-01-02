using TMPro;
using UnityEngine;

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
            healthText.transform.SetParent(gameObject.transform, false);
            healthText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            healthText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            healthText.fontSize = Infoholic.FontSize;
            healthText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Lives
            livesText = new GameObject().AddComponent<TextMeshProUGUI>();
            livesText.gameObject.AddComponent<DestroyOnUnparent>();
            livesText.transform.SetParent(gameObject.transform, false);
            livesText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            livesText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            livesText.fontSize = Infoholic.FontSize;
            livesText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Block Cooldown
            blockCooldownText = new GameObject().AddComponent<TextMeshProUGUI>();
            blockCooldownText.gameObject.AddComponent<DestroyOnUnparent>();
            blockCooldownText.transform.SetParent(gameObject.transform, false);
            blockCooldownText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            blockCooldownText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            blockCooldownText.fontSize = Infoholic.FontSize;
            blockCooldownText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Additional Blocks
            blockCountText = new GameObject().AddComponent<TextMeshProUGUI>();
            blockCountText.gameObject.AddComponent<DestroyOnUnparent>();
            blockCountText.transform.SetParent(gameObject.transform, false);
            blockCountText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            blockCountText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            blockCountText.fontSize = Infoholic.FontSize;
            blockCountText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Damage
            damageText = new GameObject().AddComponent<TextMeshProUGUI>();
            damageText.gameObject.AddComponent<DestroyOnUnparent>();
            damageText.transform.SetParent(gameObject.transform, false);
            damageText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            damageText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            damageText.fontSize = Infoholic.FontSize;
            damageText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Knockback
            knockbackText = new GameObject().AddComponent<TextMeshProUGUI>();
            knockbackText.gameObject.AddComponent<DestroyOnUnparent>();
            knockbackText.transform.SetParent(gameObject.transform, false);
            knockbackText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            knockbackText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            knockbackText.fontSize = Infoholic.FontSize;
            knockbackText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Life Steal
            lifeStealText = new GameObject().AddComponent<TextMeshProUGUI>();
            lifeStealText.gameObject.AddComponent<DestroyOnUnparent>();
            lifeStealText.transform.SetParent(gameObject.transform, false);
            lifeStealText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            lifeStealText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            lifeStealText.fontSize = Infoholic.FontSize;
            lifeStealText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bullet Growth
            bulletGrowthText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletGrowthText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletGrowthText.transform.SetParent(gameObject.transform, false);
            bulletGrowthText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletGrowthText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            bulletGrowthText.fontSize = Infoholic.FontSize;
            bulletGrowthText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bullet Slow
            bulletSlowText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletSlowText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletSlowText.transform.SetParent(gameObject.transform, false);
            bulletSlowText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletSlowText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            bulletSlowText.fontSize = Infoholic.FontSize;
            bulletSlowText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);


            // Movement Speed
            movementSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            movementSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            movementSpeedText.transform.SetParent(gameObject.transform, false);
            movementSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            movementSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            movementSpeedText.fontSize = Infoholic.FontSize;
            movementSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Jump Height
            jumpHeightText = new GameObject().AddComponent<TextMeshProUGUI>();
            jumpHeightText.gameObject.AddComponent<DestroyOnUnparent>();
            jumpHeightText.transform.SetParent(gameObject.transform, false);
            jumpHeightText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            jumpHeightText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            jumpHeightText.fontSize = Infoholic.FontSize;
            jumpHeightText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Player Size
            playerSizeText = new GameObject().AddComponent<TextMeshProUGUI>();
            playerSizeText.gameObject.AddComponent<DestroyOnUnparent>();
            playerSizeText.transform.SetParent(gameObject.transform, false);
            playerSizeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            playerSizeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            playerSizeText.fontSize = Infoholic.FontSize;
            playerSizeText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Attack Speed
            attackSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            attackSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            attackSpeedText.transform.SetParent(gameObject.transform, false);
            attackSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            attackSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            attackSpeedText.fontSize = Infoholic.FontSize;
            attackSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Projectile Speed
            projectileSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSpeedText.transform.SetParent(gameObject.transform, false);
            projectileSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            projectileSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            projectileSpeedText.fontSize = Infoholic.FontSize;
            projectileSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Projectile Simulation Speed
            projectileSimulationSpeedText = new GameObject().AddComponent<TextMeshProUGUI>();
            projectileSimulationSpeedText.gameObject.AddComponent<DestroyOnUnparent>();
            projectileSimulationSpeedText.transform.SetParent(gameObject.transform, false);
            projectileSimulationSpeedText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            projectileSimulationSpeedText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            projectileSimulationSpeedText.fontSize = Infoholic.FontSize;
            projectileSimulationSpeedText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Reload Time
            reloadTimeText = new GameObject().AddComponent<TextMeshProUGUI>();
            reloadTimeText.gameObject.AddComponent<DestroyOnUnparent>();
            reloadTimeText.transform.SetParent(gameObject.transform, false);
            reloadTimeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            reloadTimeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            reloadTimeText.fontSize = Infoholic.FontSize;
            reloadTimeText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bullet Gravity
            bulletGravityText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletGravityText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletGravityText.transform.SetParent(gameObject.transform, false);
            bulletGravityText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletGravityText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            bulletGravityText.fontSize = Infoholic.FontSize;
            bulletGravityText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Ammo
            ammoText = new GameObject().AddComponent<TextMeshProUGUI>();
            ammoText.gameObject.AddComponent<DestroyOnUnparent>();
            ammoText.transform.SetParent(gameObject.transform, false);
            ammoText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            ammoText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            ammoText.fontSize = Infoholic.FontSize;
            ammoText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bullets
            bulletsText = new GameObject().AddComponent<TextMeshProUGUI>();
            bulletsText.gameObject.AddComponent<DestroyOnUnparent>();
            bulletsText.transform.SetParent(gameObject.transform, false);
            bulletsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            bulletsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            bulletsText.fontSize = Infoholic.FontSize;
            bulletsText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bullet Range
            rangeText = new GameObject().AddComponent<TextMeshProUGUI>();
            rangeText.gameObject.AddComponent<DestroyOnUnparent>();
            rangeText.transform.SetParent(gameObject.transform, false);
            rangeText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            rangeText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            rangeText.fontSize = Infoholic.FontSize;
            rangeText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Reflects
            reflectsText = new GameObject().AddComponent<TextMeshProUGUI>();
            reflectsText.gameObject.AddComponent<DestroyOnUnparent>();
            reflectsText.transform.SetParent(gameObject.transform, false);
            reflectsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            reflectsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            reflectsText.fontSize = Infoholic.FontSize;
            reflectsText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            // Bursts
            burstsText = new GameObject().AddComponent<TextMeshProUGUI>();
            burstsText.gameObject.AddComponent<DestroyOnUnparent>();
            burstsText.transform.SetParent(gameObject.transform, false);
            burstsText.gameObject.transform.localScale = new Vector3(Infoholic.statsToggled, Infoholic.statsToggled, Infoholic.statsToggled);
            burstsText.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            burstsText.fontSize = Infoholic.FontSize;
            burstsText.color = new Color(Infoholic.ColorR, Infoholic.ColorG, Infoholic.ColorB, Infoholic.Opacity);

            SetTextPosition();
        }

        public void Update()
        {
            if (player is null || player == null) 
            {
                 return;
            }

            healthText.text = $"HP: {player.data.health:f0} / {player.data.maxHealth:f0}";
            damageText.text = $"DMG: {(gun.damage * 55f) * gun.bulletDamageMultiplier:f0}";
            livesText.text = $"Lives: {player.data.stats.respawns + 1:f0}";
            blockCooldownText.text = $"Block CD: {block.Cooldown():f2}s";
            blockCountText.text = $"Block Count: {block.additionalBlocks + 1:f0}";
            movementSpeedText.text = $"Move SPD: {player.data.stats.movementSpeed:f2}";
            jumpHeightText.text = $"Jump Height: {player.data.stats.jump:f2}";
            playerSizeText.text = $"Player Size: {player.data.stats.sizeMultiplier:f2}";
            knockbackText.text = $"Knockback: {gun.knockback:f2}";
            lifeStealText.text = $"Life Steal: {player.data.stats.lifeSteal:f2}";
            bulletGrowthText.text = $"Damage Grow: {gun.damageAfterDistanceMultiplier:f2}";
            bulletSlowText.text = $"Bullet Slow: {gun.slow:f2}";
            attackSpeedText.text = $"Attack SPD: {(gun.attackSpeed * gun.attackSpeedMultiplier):f2}s";
            projectileSpeedText.text = $"Bullet SPD: {gun.projectileSpeed:f2}";
            projectileSimulationSpeedText.text = $"Projectile SPD: {gun.projectielSimulatonSpeed:f2}";
            reloadTimeText.text = $"Reload Time: {(gun.GetComponentInChildren<GunAmmo>().reloadTime + gun.GetComponentInChildren<GunAmmo>().reloadTimeAdd) * gun.GetComponentInChildren<GunAmmo>().reloadTimeMultiplier:f2}s";
            bulletGravityText.text = $"Bullet Gravity: {gun.gravity:f2}";
            ammoText.text = $"Ammo: {gun.GetComponentInChildren<GunAmmo>().maxAmmo:f0}";
            bulletsText.text = $"Bullets: {gun.numberOfProjectiles:f0}";
            rangeText.text = $"Bullet Range: {gun.destroyBulletAfter:f2}";
            reflectsText.text = $"Bounces: {gun.reflects:f0}";
            burstsText.text = $"Bursts: {gun.bursts:f0}";

            UpdateTextScale();

            if (Input.GetKeyDown(Infoholic.DetectedKey))
            {
                Toggle();
            }

            if (!Infoholic.inGame)
            {
                Destroy(this.gameObject);
            }
        }

        private void Toggle()
        {
            if (!Infoholic.statsToggledPressed)
            {
                Infoholic.statsToggledPressed = true;
            }
            else
            {
                Infoholic.statsToggledPressed = false;
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
            if (!Infoholic.statsToggledPressed)
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

            void DestroyStats()
            {
                Destroy(this.gameObject);
            }
        }
    }
}