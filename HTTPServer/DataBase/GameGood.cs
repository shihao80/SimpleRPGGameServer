using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class GameGood
    {
        public string playerId { set; get; }//-- 当前服务器中角色唯一ID
        public int goodId { set; get; }//-- 物品ID
        public string goodName { set; get; }//  -- 物品名字
        public string goodDescrip { set; get; }// -- 物品描述
        public int goodBuyPrice { set; get; }//  -- 物品买入价格
        public int goodSellPrice { set; get; }//  -- 物品卖出价格
        public string goodIconPath { set; get; }//    -- 物品 图标路径
        public string goodItemType { set; get; }//   -- 物品基本类别 Weapon Consumable Armor
        public int goodCount { set; get; }//         -- 物品数量
        public string goodType { set; get; }//       -- 物品类型 衣服/头盔 /手套 武器/首饰/项链
        public string goodEquip { get; set; } // -- 武器是否装配上了 是就和上面属性一致
        public int ArmorBlood { set; get; }//       -- 防具加气血量
        public int ArmorDefend { set; get; }//      -- 防具加防御
        public int ArmorAgility { set; get; }//     -- 防具加敏捷
        public int ConsumableBcakHP { set; get; }//  -- 药品 加的HP
        public int ConsumableBcakMP { set; get; }//  -- 药品 加的MP
        public int WeaponDamage { set; get; }//     -- 武器(首饰) 加的攻击
        public int WeaponMP { set; get; }//       -- 武器(首饰) 加的魔能MP

        public GameGood()
        {
        }

        public GameGood(string playerId, int goodId, string goodName, 
            string goodDescrip, int goodBuyPrice,
            int goodSellPrice, string goodIconPath, 
            string goodItemType, int goodCount, string goodType, string goodEquip,
            int ArmorBlood, int ArmorDefend, int ArmorAgility, 
            int ConsumableBcakHP, int ConsumableBcakMP, 
            int WeaponDamage, int WeaponMP)
        {
            this.playerId = playerId;
            this.goodId = goodId;
            this.goodName = goodName;
            this.goodDescrip = goodDescrip;
            this.goodBuyPrice = goodBuyPrice;
            this.goodSellPrice = goodSellPrice;
            this.goodIconPath = goodIconPath;
            this.goodItemType = goodItemType;
            this.goodCount = goodCount;
            this.goodType = goodType;
            this.goodEquip = goodEquip;
            this.ArmorBlood = ArmorBlood;
            this.ArmorDefend = ArmorDefend;
            this.ArmorAgility = ArmorAgility;
            this.ConsumableBcakHP = ConsumableBcakHP;
            this.ConsumableBcakMP = ConsumableBcakMP;
            this.WeaponDamage = WeaponDamage;
            this.WeaponMP = WeaponMP;
        }
    }
}
