using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Buffs
{
    public class ExampleDefenseBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Nature protection");
            Description.SetDefault("Grants +4 defense.");
			DisplayName.AddTranslation(GameCulture.Russian, "Защита природы");
			Description.AddTranslation(GameCulture.Russian, "Дарует +4 защиты");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 4; //Grant a +4 defense boost to the player while the buff is active.
        }
    }
}