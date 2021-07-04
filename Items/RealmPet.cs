using RothurMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RothurMod.Items
{
	public class RealmPet : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			// DisplayName.SetDefault("Realm Pet");
			// Tooltip.SetDefault("Summons a Realm Pet to follow aimlessly behind you");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.RealmPet>();
			item.buffType = ModContent.BuffType<Buffs.RealmPet>();
			item.shootSpeed = 15; 
		}


		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
