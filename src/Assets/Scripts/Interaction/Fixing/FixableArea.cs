using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixableArea : MonoBehaviour
{
    public FixableObjectStage FixableObjectStage { get; set; }

    [SerializeField]
    private GameObject[] NoodleStages;

    private int _noodlesPerStage = 1;
    private int _noodlesUsedCount = 0;

    private int _gluePerStage = 1;
    private int _glueStageCount = 3;
    private int _glueUsedCount = 0;

    [SerializeField]
    private GameObject[] GrinderStages;

    private int _grinderPerStage = 1;
    private int _grinderUsedCount = 0;

    private int _paintPerStage = 1;
    private int _paintStageCount = 3;
    private int _paintUsedCount = 0;

    // Glue stages will dim noodle texture.

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

    public void FixWithGlue()
    {
        if (FixableObjectStage == FixableObjectStage.FilledWithNoodles)
        {
            _glueUsedCount++;

            if (_glueUsedCount % _gluePerStage == 0)
            {
                DisplayGlueStage(_glueUsedCount / _gluePerStage);
            }

            if (_glueUsedCount >= _glueStageCount * _gluePerStage)
            {
                FixableObjectStage = FixableObjectStage.FilledWithGlue;
            }
        }
    }

    private void DisplayNoodleStage(int noodleStage)
    {
        var noodle = NoodleStages[noodleStage - 1];
        noodle.SetActive(true);
    }

    private void DisplayGlueStage(int glueStage)
    {
        foreach (var noodleStage in NoodleStages)
        {
            MeshRenderer meshRenderer = noodleStage.GetComponent<MeshRenderer>();
            Material oldMaterial = meshRenderer.material;

            oldMaterial.color = oldMaterial.color + (Color.grey * 0.1f);

            meshRenderer.material = oldMaterial;
        }
    }

    private void DisplayGrindingStage()
    {
        foreach (var grinding in GrinderStages)
        {
            grinding.SetActive(false);
        }
    }

    internal void FixWithGrinding()
    {
        if (FixableObjectStage == FixableObjectStage.FilledWithGlue)
        {
            int grindingStageCount = 1;

            _grinderUsedCount++;

            if (_grinderUsedCount % _grinderPerStage == 0)
            {
                DisplayGrindingStage();
            }

            if (_grinderUsedCount >= grindingStageCount * _grinderPerStage)
            {
                FixableObjectStage = FixableObjectStage.Grinded;
            }
        }
    }
}
