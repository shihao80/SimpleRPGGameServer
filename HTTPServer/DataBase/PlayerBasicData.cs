using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    /// <summary>
    /// 基本人物属性
    /// </summary>
    public static class PlayerBasicData
    {
        public static float jumpCD = 1.4f;       //修改碰撞的最长时间
        public static float jumpSpeed = 4.0f;    //橘色跳跃高度
        public static float Rotatespeed = 3.0f;  //摄像机旋转速度
        public static float scrollSpeed = 0.05f; //摄像机缩放速度
        public static float maxCameraPos = 5.5f;    //镜头最大缩放
        public static float minCameraPos = 0.5f;    //镜头最小缩放

        public static string httpURL = "http://127.0.0.1:4051/"; //服务器网址



        ///////////////////////////////基本用户角色数据///////////////////////////////
        public static float SwordBsic = 1.6f; //近战职业的属性是基础的1.6

        public static int playerLevel = 1;   //-- 角色等级
        public static int playerNowExp = 0;    //         -- 角色当前经验
        public static int playerUpExp = 1000;        //        -- 角色升级所需经验
        public static int playerNowHP = 7000;   //            -- 角色当前HP
        public static int playerNowMP = 6000;  //  ,           -- 角色当前MP
        public static float playerMoveSpeed = 2.7f;   //  ,           -- 角色移动速度
        public static float playerRunSpeed = 5.4f;   //  ,           -- 角色奔跑速度
        public static string playerElement = "全元素";    // ,      -- 角色元素属性
        public static int playerMaxHP = 8000;   //  ,           -- 倦色气血上限
        public static int playerMaxMP = 7000;  //  ,           -- 角色魔能上限
        public static int playerAttack = 200;   //  ,           -- 角色魔法攻击
        public static int playerElementHurt = 20;    //  ,           -- 角色元素伤害
        public static int playerAttackHit = 20; //  ,           -- 角色攻击命中
        public static int playerAttackCrit = 10; //  ,           -- 角色攻击会心(暴击点数)
        public static float playerCritHurt = 1.5f; // ,           -- 角色会心伤害(暴击百分比)
        public static int playerDefend = 200; // ,           -- 角色基础防御
        public static int playerAgility = 20;    //  ,           -- 角色基础敏捷
        public static int playerMagicDefend = 10; //  ,   
        public static int playerGCoins = 0; //初始金币
        public static int playerSCoins = 1000; //初始银币

        public static GamePlayer getBasicGamePlaye(string userId, string userServer, string playerId
            , string playerPrefabName, string playerName)
        {
            return new GamePlayer(userId, userServer, playerId, playerPrefabName, playerName,
                PlayerBasicData.playerLevel, PlayerBasicData.playerNowExp, PlayerBasicData.playerUpExp,
                PlayerBasicData.playerNowHP, PlayerBasicData.playerNowMP, PlayerBasicData.playerMoveSpeed,
                PlayerBasicData.playerRunSpeed, PlayerBasicData.playerElement, PlayerBasicData.playerMaxHP,
                PlayerBasicData.playerMaxMP, PlayerBasicData.playerAttack, PlayerBasicData.playerElementHurt,
                PlayerBasicData.playerAttackHit, PlayerBasicData.playerAttackCrit, PlayerBasicData.playerCritHurt,
                PlayerBasicData.playerDefend, PlayerBasicData.playerAgility, PlayerBasicData.playerMagicDefend,
                PlayerBasicData.playerGCoins, PlayerBasicData.playerSCoins);
        }
    }
}
