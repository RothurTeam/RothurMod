using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Projectiles
{
	public class ThrowingKnife : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Big Throwing Knife");
			DisplayName.AddTranslation(GameCulture.Russian, "Большой метательный нож");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ThrowingKnife);
			aiType = ProjectileID.ThrowingKnife;
			projectile.width = 40;
			projectile.height = 20;
		}

		//public override bool PreKill(int timeLeft) {
			//projectile.type = ProjectileID.Starfury;
			//return true;
		//}

		
	}
}