using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Buffs
{
    public class DefenseBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Demon protection");
            Description.SetDefault("Grants +6 defense.");
			DisplayName.AddTranslation(GameCulture.Russian, "Защита демона");
			Description.AddTranslation(GameCulture.Russian, "Дарует +6 защиты");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 6; //Grant a +4 defense boost to the player while the buff is active.
        }
    }
}