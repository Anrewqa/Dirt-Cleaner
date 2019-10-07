using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DisableTimer))]
public class ObjectLauncher : MonoBehaviour
{
    #region ForceDebug
    [Header("Force vector.up rotation by axis")]
    [SerializeField] private bool debugX;
    [SerializeField] private bool debugZ;
    [Range(0, 45)]
    [SerializeField] private float xMin;
    [Range(0, 45)]
    [SerializeField] private float zMin;
    [Range(45, 90)]
    [SerializeField] private float xMax;
    [Range(45, 90)]
    [SerializeField] private float zMax;
    private void OnDrawGizmos()
    {
        if (debugX)
        {
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(xMin, 0, 0) * Vector3.up);
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(xMax, 0, 0) * Vector3.up);
        }
        if (debugZ)
        {
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, zMin) * Vector3.up);
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, zMax) * Vector3.up);
        }
    }
    #endregion


    [Header("Launch properties")]
    private bool launched;
    [SerializeField] private bool launchOnRage;
    [SerializeField] float minMagnitude;
    [SerializeField] float maxMagnitude;

    [Header("Relations")]
    [SerializeField] private DisableTimer disableTimer;


    private Vector3 initialForce;    

    private void Update()
    {
        if (launched)
        {
            transform.position += initialForce;
        }
    }

    public void Launch()
    {
        AddToResetList();
        if (!launchOnRage)
        {
            launched = true;
            initialForce = Quaternion.Euler(Random.Range(xMin,xMax), 0, Random.Range(zMin,xMax)) * Vector3.up;
            initialForce *= Random.Range(minMagnitude, maxMagnitude);
            disableTimer.StartTimer();
        }
    }

    public void RageLaunch()
    {
        AddToResetList();
        launched = true;
        initialForce = Quaternion.Euler(Random.Range(xMin, xMax), 0, Random.Range(zMin, xMax)) * Vector3.up;
        initialForce *= maxMagnitude;
        disableTimer.StartTimer();
    }

    public void ResetLauncher()
    {
        launched = false;
        gameObject.SetActive(true);
    }

    private void AddToResetList()
    {
        if (ObjectsForReset.objects.Contains(gameObject)) Debug.Log(gameObject.name + "already in list");
        ObjectsForReset.objects.Add(gameObject);
    }

}
