using RothurMod.Items.ExampleDamageClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ExampleRobe : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Necro robe");
			Tooltip.SetDefault(""
				+ "+6% necro damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Роба некроманта");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+6% некромантического урона");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 0;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player) {
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.06f;
		}
		
		public override bool Autoload(ref string name)
        {
            mod.AddEquipTexture(new DressLegs(), null, EquipType.Legs, "ExampleRobeL", "RothurMod/Items/Armor/ExampleRobeL_Legs");
            return true;
        }

		public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            robes = true;

            if (male) equipSlot = mod.GetEquipSlot("ExampleRobeL_Legs", EquipType.Legs);
        }

		public class DressLegs : EquipTexture
    	{
    	}

		public override void DrawHands(ref bool drawHands, ref bool drawArms) {
			drawHands = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TornFabric", 6);
			recipe.AddIngredient(null, "ExampleSoul", 2);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}