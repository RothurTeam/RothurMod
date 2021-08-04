using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RothurMod.Dusts;
using Terraria.Localization;
 
namespace RothurMod.Projectiles
{
    public class ObserverProj : ModProjectile
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("A piece of energy");
			DisplayName.AddTranslation(GameCulture.Russian, "Частичка энергии");
		}
		
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 26;
            projectile.friendly = false;                               
            projectile.hostile = true;                        
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
			projectile.timeLeft = 180;
        }
		
		public override Color? GetAlpha(Color lightColor) {
			return new Color(255, 255, 0, 0) * (1f - (float)projectile.alpha / 255f);
		}
 
        public override void AI()
        {
                                                                //this is projectile dust
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