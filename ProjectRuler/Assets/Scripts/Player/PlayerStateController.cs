using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    // プレイヤーに起こりうる状態
    public enum PlayerStateEnum
    {
        Idle,           // アイドル
        Move,           // 移動
        Avoidance,      // 回避
        ReceiveDamage,  // ダメージを受ける
        Jump,           // ジャンプ
        Hack,           // ハッキング
        Robbery,        // 強奪
        WeaoponAction,  // 装備のアクション
        None            // なし
    }

    // プレイヤーステートのリスト
    private Dictionary<PlayerStateEnum, IPlayerState> stateDic = new Dictionary<PlayerStateEnum, IPlayerState>();
    // 現在実行されているステート
    private IPlayerState activeState = null;
    public IPlayerState ActiveState { get { return activeState; } }
    // 1フレーム前に実行されていたステート
    private IPlayerState lastState = null;
    public IPlayerState LastState { get { return lastState; } }



    void Start()
    {
        CreateState();
        activeState = stateDic[PlayerStateEnum.Idle];
        lastState = activeState;
    }

    void Update()
    {
        // アクティブなステートを実行
        activeState.Execute();
        lastState = activeState;
    }

    // ステートを変更
    public void ChangeActiveState(PlayerStateEnum state)
    {

    }


    private void CreateState()
    {
        stateDic.Add(PlayerStateEnum.Idle, new PlayerIdleState());
    }
}
