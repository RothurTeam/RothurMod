using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RothurMod.Projectiles
{
	public class BigShuriken : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Big Shuriken");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Shuriken);
			aiType = ProjectileID.Shuriken;
		}

		//public override bool PreKill(int timeLeft) {
			//projectile.type = ProjectileID.Starfury;
			//return true;
		//}

		
	}
}