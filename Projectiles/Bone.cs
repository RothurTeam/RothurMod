using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Projectiles
{
	public class Bone : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.magic = false;
			projectile.penetrate = 3;
			projectile.timeLeft = 500;
			//projectile.rotation += MathHelper.ToRadians(16);
			//projectile.CloneDefaults(ProjectileID.Starfury);
			//aiType = ProjectileID.Starfury;
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			else {
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
					projectile.rotation = projectile.velocity.ToRotation() + 0.85f;
					projectile.rotation += MathHelper.ToRadians(16);
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}
		
		public override void AI()
         {      
            Main.player[projectile.owner].direction = projectile.direction;    

                projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 10)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.25f;
                projectile.velocity.X = projectile.velocity.X + 0.01f;
                projectile.rotation -= MathHelper.ToRadians(-40);
            }

            if (projectile.ai[0] <= 10)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0f;
                projectile.velocity.X = projectile.velocity.X + 0f;
                projectile.rotation -= MathHelper.ToRadians(-30);
            } 
        }

		public override void Kill(int timeLeft) {
			
			Main.PlaySound(SoundID.Item10, projectile.position);;
		}

		

		
	}
}