using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    /// <summary>
    /// 基本武器属性
    /// </summary>
    public static class GoodBasicData
    {
        public static GameGood GetGood_Magic_Weapon_武器(string playerId ,int goodId)
        {
            return new GameGood(playerId, goodId, "精制·新手法杖",
                "SAO发放的通用法杖",
                0, 500,
                "rpg_Weapon_09", "Weapon", 1, "武器", "True",
                0, 0, 0,
                0, 0,
                320, 1000);
        }

        public static GameGood GetGood_Sword_Weapon_武器(string playerId, int goodId)
        {
            return new GameGood(playerId, goodId, "精制·新手长剑",
                "SAO发放的通用大刀",
                0, 500,
                "rpg_Weapon_46", "Weapon", 1, "武器", "True",
                0, 0, 0,
                0, 0,
                500, 800);
        }

        public static GameGood GetGood_Weapon_首饰(string playerId, int goodId)
        {
            return new GameGood(playerId, goodId, "铜制·琼玉戒",
                "新手村购买的的的新手戒指",
                15, 50,
                "rpg_Weapon_shoushi_26", "Weapon", 1, "首饰","NULL",
                0, 0, 0, 
                0, 0, 
                150, 800);
        }

        public static GameGood GetGood_Consumable_HP(string playerId, int goodId)
        {
            return new GameGood(playerId, goodId, "小·气血瓶",
                "SAO新手配备的药水,可以回复一定的气血",
                50, 10,
                "rpg_Consumable_HP_01", "Consumable", 50, "药品", "NULL",
                0, 0, 0,
                2200, 0,
                0, 0);
        }

        public static GameGood GetGood_Consumable_MP(string playerId, int goodId)
        {
            return new GameGood(playerId, goodId, "小·气魔瓶",
                "SAO新手配备的药水,可以回复一定的气/魔能",
                50, 10,
                "rpg_Consumable_MP_03", "Consumable", 50, "药品", "NULL",
                0, 0, 0,
                0, 1500,
                0, 0);
        }

        public static GameGood GetGood_Armor_上衣(string playerId, int goodId)
        {
            return new GameGood(playerId, goodId, "金凯·战士铠甲",
                "SAO统一发放的新手上衣,可以增加基础属性.",
                500, 180,
                "rpg_Armor_yifu_19", "Armor", 1, "上衣", "NULL",
                1800, 140, 10,
                0, 0,
                0, 0);
        }
    }
}
