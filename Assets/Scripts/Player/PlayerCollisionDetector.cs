using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionDetector : MonoBehaviour
{
    private PlayerStateTracker stateTracker;
    [SerializeField] private int obstacleLayerNumber;
    [SerializeField] private ToggleObject toggleObject;
    [SerializeField] private PlayerMover mover;

    public UnityEvent death = new UnityEvent();
    public UnityEvent win = new UnityEvent();

    private void Awake()
    {
        stateTracker = GetComponent<PlayerStateTracker>();
    }


    //Sphere collider triggered
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ObjectLauncher>())
        {
            if (stateTracker.CurrentPlayerState == PlayerStateTracker.PlayerState.Normal)
            {
                if(other.GetComponent<ScorePointsContainer>()) ScoreTracker.AddPoints(other.GetComponent<ScorePointsContainer>().Points);
                other.GetComponent<ObjectLauncher>().Launch();
            }
            else if (stateTracker.CurrentPlayerState == PlayerStateTracker.PlayerState.Rage)
            {
                other.GetComponent<ObjectLauncher>().RageLaunch();
            }
        }
        if (other.GetComponent<FinishTrigger>())
        {
            win?.Invoke();
        }
        
    }

    //Box (mesh) collider collide
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == obstacleLayerNumber && stateTracker.CurrentPlayerState != PlayerStateTracker.PlayerState.Rage)
        {
            //Death
            death?.Invoke();
        }
    }

}
