using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MH : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("MH");
			Tooltip.SetDefault("+6% damage to ranged weapons");
			DisplayName.AddTranslation(GameCulture.Russian, "MH");
			Tooltip.AddTranslation(GameCulture.Russian, "+6% к урону дальнобойного оружия");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 10;
			item.value = 2000;
			item.rare = 1;
			item.defense = 3;
		}
		
		public override void UpdateEquip(Player player) {
			player.rangedDamage += 0.06f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<MB>() && legs.type == ItemType<ML>();
		}

		public override void UpdateArmorSet(Player player) {
			if (GetLang() == "ru-RU") {
					player.setBonus = "+12% дальнеого урона";
					} else {
					player.setBonus = "+12% range damage";
					}
			player.rangedDamage += 0.1f;
			/* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
		}
		
		private string GetLang(){ 
            var culture = Language.ActiveCulture.Name;
            return culture;
			}
			
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Granite, 25);
			recipe.AddIngredient(ItemID.GlowingMushroom, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}