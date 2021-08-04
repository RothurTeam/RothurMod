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
	public class NecromancersApprenticeStaff : ExampleDamageItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Staff Of The Wicked Nature");
			Tooltip.SetDefault("");
			Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Посох ученика нечестивой природы");
		}
		
		

		public override void SafeSetDefaults() {
			item.CloneDefaults(ItemID.AmethystStaff);
			item.Size = new Vector2(28, 36);
			item.damage = 11;
			item.magic = false;
			item.knockBack = 4;
			item.rare = 0;
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.HoldingOut;
			//exampleResourceCost = 10;
			
		}
		
		
	}
}