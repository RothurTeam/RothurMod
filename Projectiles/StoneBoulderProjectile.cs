using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RothurMod.Projectiles
{
	public class StoneBoulderProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stone Boulder");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
			aiType = ProjectileID.BoulderStaffOfEarth;
			//projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.hostile = false;
			//projectile.penetrate = -1;
			projectile.width = 27;
			projectile.height = 27;
			projectile.timeLeft = 180;
		}

		//public override bool PreKill(int timeLeft) {
			//projectile.type = ProjectileID.Starfury;
			//return true;
		//}

		
	}
}