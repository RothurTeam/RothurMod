using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RothurMod.Dusts;
 
namespace RothurMod.Projectiles
{
    public class BalanceProj : ModProjectile
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Balance Projectile");
		}
		
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = 3;                                 
            projectile.hostile = false;
            projectile.melee = true;                        
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
        }
 
        public override void AI()
        {
                                                                //this is projectile dust
            //int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 2, projectile.height + 2, mod.DustType("DustName"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 2.9f);
            //Main.dust[DustID2].noGravity = true;
                                                          //this make that the projectile faces the right way
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            projectile.alpha = (int)projectile.localAI[0] * 2;
           
            if (projectile.localAI[0] > 180f) //projectile time left before disappears
            {
                projectile.Kill();
            }
			
			if (Main.rand.NextBool(2)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<DeBalanceDust>(), projectile.velocity.X * 0.65f, projectile.velocity.Y * 0.65f);
			}
			if (Main.rand.NextBool(4)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<BalanceDust>(), projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.75f);
			}
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<BalanceDust>(), projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.75f);
			}
           
        }
        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 10) //once the frameCounter has reached 10 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 3) //if past the last frame
projectile.frame = 0; //go back to the first frame
            }
            return true;
        }
    }
}