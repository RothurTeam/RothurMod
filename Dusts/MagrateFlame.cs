using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Dusts
{
	public class MagrateFlame : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale = 2f;
		}
		
		//public override Color? GetAlpha(Color lightColor) => new Color(199, 21, 133, 0);
		
		//public override Color? GetAlpha(Color lightColor) {
			//return Color.White;
			//return new Color(199, 21, 133, 0) * (1f - (float)projectile.alpha / 255f);
		//}

		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			dust.scale -= 0.1f;
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			else {
				float strength = dust.scale / 2f;
				Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), dust.color.R / 255f * 0.5f * strength, dust.color.G / 255f * 0.5f * strength, dust.color.B / 255f * 0.5f * strength);
			}
			return false;
		}
	}
}