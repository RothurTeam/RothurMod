using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RealmHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Realm helmet");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовый шлем");
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
			return body.type == ItemType<RealmBreastplate>() && legs.type == ItemType<RealmLeggings>();
		}
		
		private string GetLang(){ 
            var culture = Language.ActiveCulture.Name;
            return culture;
			}

		public override void UpdateArmorSet(Player player) {
			if (GetLang() == "ru-RU") {
					player.setBonus = "+10% к увеличению скорости передвижения ";
					} else {
					player.setBonus = "+10% increased movement speed";
					}
			player.moveSpeed += 0.1f;
			/* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RealmShard", 10);
			recipe.AddTile(TileID.WorkBenches);  
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}