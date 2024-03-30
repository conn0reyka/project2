using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public Aidkit aidkitPrefab;
    public float delay = 10;

    private Aidkit _aidkit;

    private void Update()
    {
        if(_aidkit != null) return;
        if(IsInvoking()) return;
        
        Invoke("CreateAidkit", delay);
    }

    private void CreateAidkit()
    {
        _aidkit = Instantiate(aidkitPrefab);
        _aidkit.transform.position = transform.position;
    }
}
