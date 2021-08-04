using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using System.IO;
using System;
using Microsoft.Xna.Framework;

namespace RothurMod.Projectiles
{
    // [AutoloadEquip(EquipType.Head)]
    public class CursedSkull : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cursed Skull");
        }
        public override void SetDefaults() {
            projectile.width = 16;
            projectile.height = 16;
            projectile.ranged = true;
            projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
        }
		
		public override Color? GetAlpha(Color lightColor) {
			//return Color.White;
			return new Color(75, 0, 130, 0) * (1f - (float)projectile.alpha / 255f);
		}

        public override void AI()
        {
		    projectile.rotation -= MathHelper.ToRadians(45);
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++) {
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5) {
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance) {
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target) {
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }
        }

		private void AdjustMagnitude(ref Vector2 vector) {
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f) {
				vector *= 10f / magnitude;
			}
		}
    }
}