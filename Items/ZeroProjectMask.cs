using Terraria.ModLoader;

namespace RothurMod.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ZeroProjectMask : ModItem
	{
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