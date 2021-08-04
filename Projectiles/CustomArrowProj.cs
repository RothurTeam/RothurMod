using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace RothurMod.Projectiles
{
    public class CustomArrowProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;  //Set the hitbox width
            projectile.height = 18;  //Set the hitbox height
            projectile.aiStyle = 1; //How the projectile works
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;   //Tells the game whether it is a ranged projectile or not
            projectile.penetrate = 3; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 500; //The amount of time the projectile is alive for
            projectile.light = 0.07f; //This defines the projectile light
            aiType = 1; // this is the projectile ai style . 1 is for arrows style
        }
        public override void AI()
        {
            
        }
 
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
 
            target.AddBuff(BuffID.Poisoned, 240);    //this adds a buff to the npc hit. 210 it the time of the buff
 
        }
        //After the projectile is dead
        public override void Kill(int timeLeft)
        {
 
            //Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, ProjectileID.DeathSickle, (int)(projectile.damage * 1.5), projectile.knockBack, Main.myPlayer); // This spawns a projectile after this projectile is dead
 
        }
 
 
    }
}