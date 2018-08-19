using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using usercmd;
public class UIData{

    //Material
    public const int CELLORIGINAL_MATERIAL = 0;
    public const int CELLRED_MATERIAL = 1;
    public const int CELLYELLOW_MATERIAL = 2;
    public const int CELLBLUE_MATERIAL = 3;
    public const int TOOLVIRUSRED_MATERIAL = 4;
    public const int TOOLVIRUSYELLOW_MATERIAL = 5;
    public const int TOOLVIRUSBLUE_MATERIAL = 6;
    //public const int TOOLVIRUSORIGINAL_MATERIAL = 7;
    //游戏总时间
    //public const int GameTime = 180;
    public const float PlayerSpeed = 2.0f;
    public static string PlayerModel = "A";
    //public static colorType playerColor;

    //public static uint roomId;
    //小地图玩家flag
    public const int RED_PLAYER = 0;
    public const int YELLOW_PLAYER = 1;
    public const int BLUE_PLAYER = 2;
    public const int HERO_PLAYER = 3;

    // 地图flag
    public const int ORIGINAL_CELL = 4;
    public const int RED_CELL = 5;
    public const int YELLOW_CELL = 6;
    public const int BLUE_CELL = 7;

    //电池Sprite
    public const int RED_ENERGY = 8;
    public const int YELLOW_ENERGY = 9;
    public const int BLUE_ENERGY = 10;
    public const int ORIGINAL_ENERGY = 11;

    //道具Sprite
    public const int VIRUS_TOOL = 12;
    public const int DYEING_TOOL = 13;
    public const int DIZZY_TOOL = 14;
    public const int ORIGINAL_TOOL = 23;

    //按钮Sprite:亮色+暗色
    public const int UPBRIGHT_BUTTON = 15;
    public const int DOWNBRIGHT_BUTTON = 16;
    public const int LEFTBRIGHT_BUTTON = 17;
    public const int RIGHTBRIGHT_BUTTON = 18;
    public const int UPORIGINAL_BUTTON = 19;
    public const int DOWNORIGINAL_BUTTON = 20;
    public const int LEFTORIGINAL_BUTTON = 21;
    public const int RIGHTORIGINSL_BUTTON = 22;


    //23已经add

    //24-25已经Add
    public const int GAMEENDSUCCESS_SPRITE = 24;
    public const int GAMEENDDEFEND_SPRITE = 25;

    //26-28; 已经Add
    public const int GAMEENDCOLOR_RED = 26;
    public const int GAMEENDCOLOR_YELLOW = 27;
    public const int GAMEENDCOLOR_BLUE = 28;


    //29-31:已经Add
    public const int PLAYERRED_BRIGHT = 29;
    public const int PLAYERYELLOW_BRIGHT = 30;
    public const int PLAYERBLYUE_BRIGHT = 31;

    //32-35
    public const int GAMEGO_THREE = 32;
    public const int GAMEGO_TWO = 33;
    public const int GAMEGO_ONE = 34;
    public const int GAMEGO_GO = 35;

    public const int SPEED_TOOL= 36;

    public static uint playerId=10000;
    public static List<Material> materialList = new List<Material>();
    public static List<Sprite> spriteList = new List<Sprite>();
}
