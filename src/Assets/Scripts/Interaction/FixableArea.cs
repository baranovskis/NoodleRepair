using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixableArea : MonoBehaviour
{
    public FixableObjectStage FixableObjectStage { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        FixableObjectStage = FixableObjectStage.Damaged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
