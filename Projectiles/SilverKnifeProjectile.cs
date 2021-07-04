using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Projectiles
{
	public class SilverKnifeProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Silver Knife");
			DisplayName.AddTranslation(GameCulture.Russian, "Серебряный нож");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ThrowingKnife);
			aiType = ProjectileID.ThrowingKnife;
			projectile.width = 25;
			projectile.height = 22;
		}

		//public override bool PreKill(int timeLeft) {
			//projectile.type = ProjectileID.Starfury;
			//return true;
		//}

		
	}
}