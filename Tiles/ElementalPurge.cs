using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Tiles
{
	public class ElementalPurge : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(GetInstance<TEElementalPurge>().Hook_AfterPlacement, -1, 0, false);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Elemental Purge");
			AddMapEntry(new Color(190, 230, 190), name);
			dustType = 11;
			disableSmartCursor = true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 32, 48, ItemType<Items.Placeable.ElementalPurge>());
			GetInstance<TEElementalPurge>().Kill(i, j);
		}


		public override bool AutoSelect(int i, int j, Item item) {
			return item.type == ItemID.Bunny;
		}
	}
}