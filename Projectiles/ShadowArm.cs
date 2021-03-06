using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;
 
namespace RothurMod.Projectiles
{
    public class ShadowArm : ModProjectile
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("ShadowArm");
		}
		
        public override void SetDefaults()
        {
            projectile.width = 16;
			projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;                                  
            projectile.hostile = false;
            projectile.magic = true;                        
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
           
            if (projectile.localAI[0] > 130f) //projectile time left before disappears
            {
                projectile.Kill();
            }
           
        }
		
		public void CreateDust(Vector2 pos) {
			if (Main.rand.NextBool(5)) {
				int dust = Dust.NewDust(pos, 16, 16, DustType<Smoke>(), 0f, 0f, 0, Color.Black);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].velocity *= 0.5f;
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
		
		 public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            int vampirism = 1; // ?????????????? ???? ????????????
            target.life -= vampirism;
            player.statLife += vampirism;
            player.HealEffect(vampirism, true); // ????????????????
        }
    }
}