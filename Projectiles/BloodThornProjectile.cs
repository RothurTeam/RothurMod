using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;
 
namespace RothurMod.Projectiles
{
    public class BloodThornProjectile : ModProjectile
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Blood Thorn"); 
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавый Шип");
			
		}
 
        public override void SetDefaults()
        {
            projectile.width = 13;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.thrown = true;
            projectile.penetrate = 3;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
            aiType = ProjectileID.BoneJavelin;
        }
 
        public override void AI()
        {            
                projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 75f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.12f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 0.99f;    // projectile velocity
            }
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<BloodyFlame>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            {
                projectile.Kill();
 
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
    }
}