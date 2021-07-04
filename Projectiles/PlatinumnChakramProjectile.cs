using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RothurMod.Projectiles
{
	public class PlatinumnChakramProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Platinumn Chakram");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ThornChakram);
			aiType = ProjectileID.ThornChakram;
		}

		//public override bool PreKill(int timeLeft) {
			//projectile.type = ProjectileID.Starfury;
			//return true;
		//}

		
	}
}