using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class GamePlayer
    {
        public string userId { set; get; }// -- 游戏账号id
        public string userServer { set; get; } // -- 角色账号所在服务器
        public string playerId { set; get; } //当前角色ID
        public string playerPrefabName { set; get; } //当前角色预设体
        public string playerName { set; get; }//  -- 角色名字
        public int playerLevel { set; get; }   //-- 角色等级
        public int playerNowExp { set; get; }   //         -- 角色当前经验
        public int playerUpExp { set; get; }     //        -- 角色升级所需经验
        public int playerNowHP { set; get; } //            -- 角色当前HP
        public int playerNowMP { set; get; }    //  ,           -- 角色当前MP
        public float playerMoveSpeed { set; get; }   //  ,           -- 角色移动速度
        public float playerRunSpeed { set; get; }  //  ,           -- 角色奔跑速度
        public string playerElement { set; get; }   // ,      -- 角色元素属性
        public int playerMaxHP { set; get; }   //  ,           -- 倦色气血上限
        public int playerMaxMP { set; get; }     //  ,           -- 角色魔能上限
        public int playerAttack { set; get; }   //  ,           -- 角色魔法攻击
        public int playerElementHurt { set; get; }  //  ,           -- 角色元素伤害
        public int playerAttackHit { set; get; } //  ,           -- 角色攻击命中
        public int playerAttackCrit { set; get; } //  ,           -- 角色攻击会心(暴击点数)
        public float playerCritHurt { set; get; } // ,           -- 角色会心伤害(暴击百分比)
        public int playerDefend { set; get; }// ,           -- 角色基础防御
        public int playerAgility { set; get; }   //  ,           -- 角色基础敏捷
        public int playerMagicDefend { set; get; } //  ,           -- 角色魔法抗性
        public int playerGCoins { set; get; }   //金币数量
        public int playerSCoins { set; get; }   //银币数量


        public GamePlayer()
        {

        }
        public GamePlayer(
            string userId, string userServer, string playerId, string playerPrefabName,
            string playerName, int playerLevel, int playerNowExp,
            int playerUpExp, int playerNowHP, int playerNowMP, float playerMoveSpeed,
            float playerRunSpeed, string playerElement, int playerMaxHP, int playerMaxMP,
            int playerAttack, int playerElementHurt, int playerAttackHit, int playerAttackCrit,
            float playerCritHurt, int playerDefend, int playerAgility, int playerMagicDefend,
            int playerGCoins, int playerSCoins)
        {
            this.userId = userId;
            this.userServer = userServer;
            this.playerId = playerId;
            this.playerPrefabName = playerPrefabName;
            this.playerName = playerName;
            this.playerLevel = playerLevel;
            this.playerNowExp = playerNowExp;
            this.playerUpExp = playerUpExp;
            this.playerNowHP = playerNowHP;
            this.playerNowMP = playerNowMP;
            this.playerMoveSpeed = playerMoveSpeed;
            this.playerRunSpeed = playerRunSpeed;
            this.playerElement = playerElement;
            this.playerMaxHP = playerMaxHP;
            this.playerMaxMP = playerMaxMP;
            this.playerAttack = playerAttack;
            this.playerElementHurt = playerElementHurt;
            this.playerAttackHit = playerAttackHit;
            this.playerAttackCrit = playerAttackCrit;
            this.playerCritHurt = playerCritHurt;
            this.playerDefend = playerDefend;
            this.playerAgility = playerAgility;
            this.playerMagicDefend = playerMagicDefend;

            this.playerGCoins = playerGCoins;
            this.playerSCoins = playerSCoins;
        }
    }
}
