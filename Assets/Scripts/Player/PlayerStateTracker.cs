using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateTracker : MonoBehaviour
{
    public enum PlayerState
    {
        Normal,
        Rage
    }

    private PlayerState currentPlayerState = PlayerState.Normal;
    public PlayerState CurrentPlayerState { get { return currentPlayerState; } set { currentPlayerState = value; } }

    public void ChangeStateToNormal()
    {
        currentPlayerState = PlayerState.Normal;
    }

    public void ChangeStateToRage()
    {
        currentPlayerState = PlayerState.Rage;
    }
}
