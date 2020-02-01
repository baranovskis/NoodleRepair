using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixableArea : MonoBehaviour
{
    public FixableObjectStage FixableObjectStage { get; set; }

    private int _noodlesPerStage = 2;
    private int _maximalNoodleCount = 10;

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
            _noodlesUsedCount++;

            if (_noodlesUsedCount % _noodlesPerStage == 0)
            {
                DisplayNoodleStage(_noodlesUsedCount / _noodlesPerStage);
            }

            if (_noodlesUsedCount >= _maximalNoodleCount)
            {
                FixableObjectStage = FixableObjectStage.FilledWithNoodles;
            }
        }
    }

    private void DisplayNoodleStage(int noodleStage)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.tag == "FixablePart")
            {
                var fixablePart = child.GetComponent<FixablePart>();

                if (fixablePart.FixOrder == noodleStage)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}
