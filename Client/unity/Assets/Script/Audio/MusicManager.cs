using UnityEngine;

//所有2D声音（不需要进行方向定位的声音）以及只在本地播放的声音都在本脚本中触发，通过外置游戏脚本调用本脚本中的接口。
public class MusicManager : MonoBehaviour {

    //全局唯一脚本，外部调用方式为  MusicManager.instance.xxx();
    public static MusicManager instance;

    //音乐部分-------------------------------------------------------------------

    //游戏开始时自动播放主菜单背景音乐
    void Start() {
	instance = this;
        //Debug.Log("Wwise：玩家完成了游戏客户端载入，开始播放音乐");
        BackToMenu();        
    }

    ////玩家回到主菜单，初始化所有音乐参数并播放主菜单音乐
    public void BackToMenu()
    {
        AkSoundEngine.PostEvent("main_menu", gameObject);
        //Debug.Log("Wwise：玩家进入主菜单，切换至主菜单音乐");
    }

    //玩家全部进入房间，比赛开始
    public void GameStart() {
        AkSoundEngine.PostEvent("game_start", gameObject);
        //AkSoundEngine.PostEvent("color_change", gameObject);
        //Debug.Log("Wwise：比赛开始，播放比赛音乐");
    }

    //初始化本地玩家颜色，以供在胜利/失败时选择对应的音乐片段。颜色字符串为red, blue, green
    public void SetPlayerColor(string color) {
        AkSoundEngine.SetState("player_color", color);
        //Debug.Log("Wwise：玩家颜色设置为" + color);
    }

    //当玩家队伍处于倒数第一的时候，播放相应音乐循环
    //切换state必须发一个消息.
    public void PlayerIsTrailing(bool status){
        if (status) {
            AkSoundEngine.SetState("player_trailing", "yes");
            //Debug.Log("Wwise：玩家队伍当前垫底，即将触发垫底音乐");
        } else {
            AkSoundEngine.SetState("player_trailing", "no");
            //Debug.Log("Wwise：玩家队伍不再垫底，即将跳出垫底音乐");
        }
    }

    //告诉Wwise当前排名第一的队伍颜色，播放对应的音乐片段。颜色字符串为red, blue, green
    public void SetLeadingPlayer(string color) {
        AkSoundEngine.SetState("leading_player", color);        
        //Debug.Log("Wwise：当前领先队伍为" + color + "，播放该队伍特有音乐");
    }

    //胜利音乐
    public void Win() {
        AkSoundEngine.PostEvent("player_win", gameObject);
        //Debug.Log("Wwise：玩家队伍获得胜利");
    }

    //失败音乐
    public void Lose() {
        AkSoundEngine.PostEvent("player_lose", gameObject);
        //Debug.Log("Wwise：玩家队伍游戏失败");
    }

    //2D音效部分-------------------------------------------------------------------

    //玩家点击UI按键时触发音效
    public void UIClick() {
        AkSoundEngine.PostEvent("UI_click", gameObject);
        Debug.Log("Wwise：玩家点击UI按键");
    }

    //玩家移动
    //public void PlayerMove() {
    //    AkSoundEngine.PostEvent("player_move", gameObject);
    //    Debug.Log("Wwise：玩家开始移动");
    //}

    //玩家停止
    //public void PlayerStop() {
    //    AkSoundEngine.PostEvent("player_stop", gameObject);
    //    Debug.Log("Wwise：玩家停止移动");
    //}

}
