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
            projectile.penetrate = 3;                       
            Main.projFrames[projectile.type] = 1;           
            projectile.hostile = false;
            projectile.magic = false;                        
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
			projectile.timeLeft = 210;
			aiType = 1;
        }
 
        public override void AI()
        {      
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Main.player[projectile.owner].direction = projectile.direction;    

                projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 10)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0f;
                projectile.velocity.X = projectile.velocity.X + 0f;
            }

            if (projectile.ai[0] <= 10)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0f;
                projectile.velocity.X = projectile.velocity.X + 0f;
            } 
        }
		
			
    }
}