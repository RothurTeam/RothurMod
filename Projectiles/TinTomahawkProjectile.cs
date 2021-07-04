using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Projectiles
{
	public class TinTomahawkProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tin Tomahawk");
			DisplayName.AddTranslation(GameCulture.Russian, "Оловянный Томагавк");
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