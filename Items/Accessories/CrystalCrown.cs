using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;

namespace RothurMod.Items.Accessories
{
    public class CrystalCrown : ModItem {
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Crystal Crown");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 22;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
			item.accessory = true;
		}
    }
}