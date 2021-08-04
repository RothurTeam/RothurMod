using System;
using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
 
namespace RothurMod.Projectiles
{
    public class MoonShotProj : ModProjectile
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Лунный выстрел");
		}
		
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.penetrate = 4;                       
            Main.projFrames[projectile.type] = 1;           
            projectile.hostile = false;
            projectile.magic = true;                        
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
			projectile.timeLeft = 210;
			aiType = 1;
			projectile.light = 0.5f;
        }
		
		public override Color? GetAlpha(Color lightColor) {
			return new Color(0, 191, 255, 0) * (1f - (float)projectile.alpha / 255f);
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