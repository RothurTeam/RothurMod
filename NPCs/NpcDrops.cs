using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace RothurMod.NPCs
{
    public class NpcDrops : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            //THIS IS AN EXAMPLE OF HOW TO MAKE ITEMS DROP FROM VANILA NPCs
 
            //if (npc.type == NPCID.WallofFlesh)   //this is where you choose the npc you want
            //{
                //if (Main.rand.Next(4) == 0) //this is the item rarity, so 4 is 1 in 5 chance that the npc will drop the item.
                //{
                    //{
						//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NecromancerEmblem"), 1); //this is where you set what item to drop, mod.ItemType("CustomSword") is an example of how to add your custom item. and 1 is the amount
                    //}
                //}
            //}
 
 
            //THIS IS AN EXAMPLE OF HOW TO MAKE ITEMS DROP FROM NPCs IN CUSTOM BIOME
            //if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>>(mod).ZoneCustomBiome) //change MyPlayer with your myplayer.cs name and ZoneCustomBiome with your zone name
            //{
                //if (Main.rand.Next(2) = = 0) //this is the item rarity, so 2 is 1 in 3 chance that the npc will drop the item.
                //{
                    //{
						//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofMight, 1); //this is where you set what item to drop
                    //}
                //}
            //}
 
            //THIS IS AN EXAMPLE OF HOW TO MAKE ITEMS DROP FROM CUSTOM NPCs
 
            //if (npc.type = = mod.NPCType("NpcName"))//this is how you add your custom npc
            //{
                //if (Main.rand.Next(2) = = 0) //this is the item rarity, so 2 is 1 in 3 chance that the npc will drop the item.
                //{
                    //{
						//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CustomSword"), 1); //this is where you set what item to drop, mod.ItemType("CustomSword") is an example of how to add your custom item. and 1 is the amount
                    //}
                //}
            //}
        }
    }
}