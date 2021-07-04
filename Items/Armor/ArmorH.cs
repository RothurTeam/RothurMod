using RothurMod.Items.ExampleDamageClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using RothurMod.Dusts;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ArmorH : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Necro hood");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Капюшон некроманта");
			Tooltip.AddTranslation(GameCulture.Russian, "");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1000;
			item.rare = 0;
			item.defense = 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<ExampleRobe>() && legs.type == ItemType<ExampleRobeL>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+5% necro damage";
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.05f;
			/* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
			
		}

		
		//public override void UpdateVanity(Player player, EquipType type) {
			//if (Main.rand.NextBool(20)) {
				//Dust.NewDust(player.position, player.width, player.height, DustType<Sparkle>());
			//}
		//}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TornFabric", 5);
			recipe.AddIngredient(null, "ExampleSoul", 2);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}