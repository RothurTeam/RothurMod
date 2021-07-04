using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RothurMod.Items
{
    public class F : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("День победы"); 
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() 
		{
            item.damage = 2;
            item.ranged = true;                   
            item.width = 22;                   
            item.height = 44;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
			item.shoot = 10;
			item.shootSpeed = 15;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 7;
            item.value = 0;
            item.rare = 0;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useTurn = true;
	    }
		
    }
}