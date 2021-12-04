using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

   
    void Update()
    {
        transform.localRotation = GyroManager.Instance.GetGyroRotation() * baseRotation;
    }
}
