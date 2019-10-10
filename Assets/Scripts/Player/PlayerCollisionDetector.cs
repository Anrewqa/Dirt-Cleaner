using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionDetector : MonoBehaviour
{
    private PlayerStateTracker stateTracker;
    [SerializeField] private int obstacleLayerNumber;
    [SerializeField] private PlayerMover mover;

    public UnityEvent death = new UnityEvent();
    public UnityEvent win = new UnityEvent();

    private void Awake()
    {
        stateTracker = GetComponent<PlayerStateTracker>();
    }


    //Trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ObjectLauncher>())
        {
            if (other.GetComponent<ScorePointsContainer>())
            {
                ScoreTracker.AddPoints(other.GetComponent<ScorePointsContainer>().UseContainer());
            }
            other.GetComponent<ObjectLauncher>().Launch(stateTracker.CurrentPlayerState);
        }

        if (other.GetComponent<FinishTrigger>())
        {
            win?.Invoke();
        }        
    }

    //Non trigger collider
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == obstacleLayerNumber && stateTracker.CurrentPlayerState != PlayerStateTracker.PlayerState.Rage)
        {
            //Death
            death?.Invoke();
        }
    }

}
