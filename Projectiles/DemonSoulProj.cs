using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using RothurMod.Items.Weapons;

namespace RothurMod.Projectiles   
{
    public class DemonSoulProj : ModProjectile {
        Random rand = new Random();

        bool spawned = false;
        int timer = 0;
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("DemonSoulProj");

            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults() {
            projectile.width = 61;
            projectile.height = 40;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
            projectile.minion = true;
            projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 180;
        }
		
		public override Color? GetAlpha(Color lightColor) {
			//return Color.White;
			return new Color(255, 165, 0, 0) * (1f - (float)projectile.alpha / 255f);
		}

        public void AnimateProjectile()
        {
            projectile.frameCounter++;
            if(projectile.frameCounter >= 8)
            {
                projectile.frame++;
                projectile.frame %= 4;
                projectile.frameCounter = 0;
            }
        }

        public override void AI() {
            int limit = 1 * 60;
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.9f);
			Main.dust[dust].noGravity = true;

            if (!spawned) {
                projectile.velocity /= 2;
                spawned = true;
            }
            Vector2 vel = projectile.velocity;

            float angle = (float)Math.Atan2(vel.X, vel.Y);

            projectile.rotation = -((angle * 180f) / 3.14f)/60+1.5f;
            if (projectile.rotation % 6 > 1.5 && projectile.rotation % 6 < 4.5) {
                projectile.spriteDirection = -1;
                projectile.rotation += 3f;
            }

            if (timer == limit) {
                projectile.velocity *= 3;
            }
			

            timer+=1;

            AnimateProjectile();
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextBool(8)) {
				target.AddBuff(BuffID.OnFire, 180, false);
			}
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1) {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int startY = frameHeight * projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			origin.X = (float)(projectile.spriteDirection == 1 ? sourceRectangle.Width - 20 : 20);

			Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture,
				projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
				sourceRectangle, drawColor, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);

			return false;
		}
    }
}