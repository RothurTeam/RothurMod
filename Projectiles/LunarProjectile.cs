using System;
using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
 
namespace RothurMod.Projectiles
{
    public class LunarProjectile : ModProjectile
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lunar Projectile");
		}
		
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = -1;                       
            Main.projFrames[projectile.type] = 1;           
            projectile.hostile = false;
            projectile.magic = false;                        
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
			projectile.timeLeft = 260;
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
           
            if (projectile.localAI[0] > 260f) //projectile time left before disappears
            {
                projectile.Kill();
            }
			if (Main.rand.NextBool(1)) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, DustType<EtherealFlame>(),
					projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
				dust.velocity += projectile.velocity * 0.8f;
				dust.velocity *= 0.5f;
			}
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<EtherealFlame>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
           
        }
		
			
        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 15) //once the frameCounter has reached 10 - change the 10 to change how fast the projectile animates
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