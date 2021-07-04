using RothurMod.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class PurityTotem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mechanical eye");
			Tooltip.SetDefault("Summons a mechanical eyes to fight for you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Механический глаз");
			Tooltip.AddTranslation(GameCulture.Russian, "Призывает механические глаза сражаться за вас");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 82;
			item.summon = true;
			item.mana = 10;
			item.width = 39;
			item.height = 39;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item44;
			item.shoot = ProjectileType<PurityWisp>();
			item.buffType = BuffType<Buffs.PurityWisp>(); //The buff added to player after used the item
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
	}
}