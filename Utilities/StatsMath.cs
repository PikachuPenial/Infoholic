using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using UnityEngine;

namespace Infoholic.Utilities
{
	internal class StatsMath
	{
		public static float GetGunBPS(Gun gun)
		{
			if (gun == null) return 0.0f;

			float attackTime = gun.attackSpeed * gun.attackSpeedMultiplier;
			int projectileCount = gun.numberOfProjectiles;

			float burstTime = gun.timeBetweenBullets;
			int burstCount = gun.bursts;

			float bps;
			if (burstCount > 1)
			{
				attackTime += (burstCount - 1) * burstTime;
				bps = burstCount * projectileCount / attackTime;
			}
			else
			{
				bps = projectileCount / attackTime;
			}

			return bps;
		}

		public static float GetGunAPS(Gun gun)
		{
			if (gun == null) return 0.0f;

			float attackTime = gun.attackSpeed * gun.attackSpeedMultiplier;

			float burstTime = gun.timeBetweenBullets;
			int burstCount = gun.bursts;

			if (burstCount > 1)
			{
				attackTime += (burstCount - 1) * burstTime;
			}

			return 1.0f / attackTime;
		}

		public static float GetGunAmmoReloadTime(GunAmmo gunAmmo)
		{
			return (gunAmmo.reloadTime + gunAmmo.reloadTimeAdd) * gunAmmo.reloadTimeMultiplier;
		}

		public static bool ApproxEqual(float numA, float numB, float precision = 10e-3f)
		{
			float diff = numA - numB;
			return Mathf.Abs(diff) <= precision;
		}
	}
}