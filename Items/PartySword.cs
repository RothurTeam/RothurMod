using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Items
{
	public class PartySword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Party Sword"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Меч вечеринки");
		}

		public override void SetDefaults() 
		{
			item.damage = 10;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
      
	    public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(5)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<PartyFlame>());
			}
		}
	  
	}   
} 