using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RothurMod.Projectiles
{
	public class TendonArrow : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tendon Arrow");
		}
		
		public override void SetDefaults()
        {
            projectile.width = 14;  //Set the hitbox width
            projectile.height = 18;  //Set the hitbox height
            projectile.aiStyle = 1; //How the projectile works
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;   //Tells the game whether it is a ranged projectile or not
            projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 500; //The amount of time the projectile is alive for
            projectile.light = 0.13f; //This defines the projectile light
            projectile.CloneDefaults(ProjectileID.UnholyArrow);
			aiType = ProjectileID.UnholyArrow;
        }

	}
}