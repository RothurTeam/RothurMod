using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class BunnyMask : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.AddTranslation(GameCulture.Russian, "Маска кролика");
			
		}
		
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = 1;
			item.vanity = true;
		}

		public override bool DrawHead() {
			return false;
		}
	}
}