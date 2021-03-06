using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Projectiles.Pets
{
	public class RealmPet : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Realm Pet"); // Automatic from .lang files
			//Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			ExamplePlayer modPlayer = player.GetModPlayer<ExamplePlayer>();
			if (player.dead) {
				modPlayer.examplePet = false;
			}
		}
	}
}