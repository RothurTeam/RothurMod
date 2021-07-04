using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RothurMod.Dusts
{
	public class LunarFlame : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.color = new Color(68,185,193);
			dust.alpha = 1;
			dust.scale = 0.5f;
			dust.velocity *= 0f;
			dust.noGravity = true;
			dust.noLight = true;
		}

		public override bool Update(Dust dust) {
			dust.rotation += dust.velocity.X / 0.1f;
			dust.position += dust.velocity;
			int oldAlpha = dust.alpha;
			dust.alpha = (int)(dust.alpha * 1.2);
			if (dust.alpha == oldAlpha) {
				dust.alpha++;
			}
			if (dust.alpha >= 255) {
				dust.alpha = 255;
				dust.active = false;
			}
			return false;
		}
	}
}