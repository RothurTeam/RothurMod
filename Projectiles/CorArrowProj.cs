using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;
 
namespace RothurMod.Projectiles
{
    public class CorArrowProj : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.damage = 3;
            projectile.width = 14;  //Set the hitbox width
            projectile.height = 18;//Set the hitbox height
            projectile.aiStyle = 1; //How the projectile works
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;   //Tells the game whether it is a ranged projectile or not
            projectile.penetrate = 2; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 500; //The amount of time the projectile is alive for
            projectile.light = 0.07f; //This defines the projectile light
            aiType = 1; // this is the projectile ai style . 1 is for arrows style
        }
        public override void AI()
        {
            if (Main.rand.NextBool(3)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<CorFlame>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
        }
 
        //After the projectile is dead
        public override void Kill(int timeLeft)
        {
			for (int k = 0; k < 5; k++) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<CorFlame>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
            //Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, ProjectileID.DeathSickle, (int)(projectile.damage * 1.5), projectile.knockBack, Main.myPlayer); // This spawns a projectile after this projectile is dead
 
        }
 
 
    }
}