using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items.NB
{
	[AutoloadEquip(EquipType.Head)]
	public class PuritySpiritMask : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Galanus Hand Mask");
			DisplayName.AddTranslation(GameCulture.Russian, "Маска руки Галануса");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = 1;
			item.vanity = true;
		}

		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor) {
			color = drawPlayer.GetImmuneAlphaPure(Color.White, shadow);
		}
	}
}
