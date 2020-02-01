using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTask : MonoBehaviour
{
    private FixableArea _fixableArea;

    public string TaskText { get; set; }

    public bool IsFinished()
    {
        return _fixableArea.FixableObjectStage
            == FixableObjectStage.Painted;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
