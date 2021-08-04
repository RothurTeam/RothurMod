using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Projectiles
{
	public class LunarBladeProj : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 45;
			projectile.height = 45;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 240;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override Color? GetAlpha(Color lightColor) {
			return new Color(0, 191, 255, 0) * (1f - (float)projectile.alpha / 255f);
		}

		
		public override void AI()
         {      
            Main.player[projectile.owner].direction = projectile.direction;    

                projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 10)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0f;
                projectile.velocity.X = projectile.velocity.X + 0f;
                projectile.rotation -= MathHelper.ToRadians(60);
            }

            if (projectile.ai[0] <= 10)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0f;
                projectile.velocity.X = projectile.velocity.X + 0f;
                projectile.rotation -= MathHelper.ToRadians(55);
            } 
        }

		public override void Kill(int timeLeft) {
			
			Main.PlaySound(SoundID.Item10, projectile.position);;
		}

		

		
	}
}