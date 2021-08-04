using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Projectiles
{
	public class ShadowBlade : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shadow Blade");
			DisplayName.AddTranslation(GameCulture.Russian, "Лезвие Тени");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.IceSickle);
			aiType = ProjectileID.IceSickle;
		}
		
		public override void Kill(int timeLeft) {
			for (int k = 0; k < 2; k++) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<CorFlame>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			//Main.PlaySound(SoundID.Item25, projectile.position);
		}

		//public override bool PreKill(int timeLeft) {
			//projectile.type = ProjectileID.Starfury;
			//return true;
		//}

		
	}
}