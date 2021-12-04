using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
        

    }
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroative;
    public void EnableGyro()
    {
        if (gyroative)
            return;
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroative = gyro.enabled;
        }
        
       }
    private void Update()
    {
        if (gyroative)
        {
            rotation = gyro.attitude;

        }
    }
    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}
    

