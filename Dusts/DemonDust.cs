using Terraria;
using Terraria.ModLoader;

namespace RothurMod.Dusts
{
	public class DemonDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.velocity *= 0.41f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 1.5f;
		}

		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.17f;
			dust.scale *= 0.95f;
			float light = 0.36f * dust.scale;
			Lighting.AddLight(dust.position, light, light, light);
			if (dust.scale < 0.51f) {
				dust.active = false;
			}
			return false;
		}
	}
}