using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixableArea : MonoBehaviour
{
    public FixableObjectStage FixableObjectStage { get; set; }

    [SerializeField]
    private GameObject[] NoodleStages;

    [SerializeField]
    private GameObject[] GrinderStages;

    private int _noodlesPerStage = 2;

    private int _noodlesUsedCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        FixableObjectStage = FixableObjectStage.Damaged;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixWithNoodles()
    {
        if (FixableObjectStage == FixableObjectStage.Damaged)
        {
            int noodleStageCount = NoodleStages.Length;

            _noodlesUsedCount++;

            if (_noodlesUsedCount % _noodlesPerStage == 0)
            {
                DisplayNoodleStage(_noodlesUsedCount / _noodlesPerStage);
            }

            if (_noodlesUsedCount >= noodleStageCount * _noodlesPerStage)
            {
                FixableObjectStage = FixableObjectStage.FilledWithNoodles;
            }
        }
    }

    private void DisplayNoodleStage(int noodleStage)
    {
        var noodle = NoodleStages[noodleStage - 1];
        noodle.SetActive(true);
    }
}
