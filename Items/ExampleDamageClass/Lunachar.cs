using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;
using RothurMod.Items;
using RothurMod.Projectiles;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System.IO;
using System.Collections.Generic;

namespace RothurMod.Items.ExampleDamageClass
{
	public class Lunachar : ExampleDamageItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lunachar");
			Tooltip.SetDefault("");
			Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Луначар");
		}
		
		

		public override void SafeSetDefaults() {
			item.CloneDefaults(ItemID.AmethystStaff);
			item.Size = new Vector2(28, 36);
			item.damage = 60;
			item.magic = false;
			item.knockBack = 4;
			item.rare = 4; 
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shoot = mod.ProjectileType ("LunacharProjectile");
			
			
		}
		
		
	}
}