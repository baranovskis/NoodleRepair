using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixManager : MonoBehaviour
{
    [SerializeField]
    private GameObject NoodleModel;
    [SerializeField]
    private GameObject GlueModel;
    [SerializeField]
    private GameObject FlexTapeModel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void FixArea(FixableArea fixableArea)
    {
        switch (fixableArea.FixableObjectStage)
        {
            case FixableObjectStage.Damaged:
                {
                    FixWithNoodles(fixableArea);
                    break;
                }
            case FixableObjectStage.FilledWithNoodles:
                {
                    FixWithGlue(fixableArea);
                    break;
                }
            case FixableObjectStage.FilledWithGlue:
                {
                    FixWithGrinding(fixableArea);
                    break;
                }
            case FixableObjectStage.Grinded:
                {
                    FixWithPainting(fixableArea);
                    break;
                }
            case FixableObjectStage.Leaking:
                {
                    FixWithFlexTape(fixableArea);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    private void FixWithFlexTape(FixableArea fixableArea)
    {
        throw new NotImplementedException();
    }

    private void FixWithPainting(FixableArea fixableArea)
    {
        var player = GetComponent<Player>();
        if (player != null)
        {
            var activeItem = player.InventoryUI.GetActiveItem();
            if (activeItem != null && activeItem.Type == Item.ItemType.Paint)
            {
                var paint = player.InventoryUI.GetItem(Item.ItemType.Paint);

                fixableArea.FixWithPainting();

                player.InventoryUI.UseInventoryItem(paint);

                if (fixableArea.FixableObjectStage == FixableObjectStage.Painted)
                {
                    player.TaskSystemUI.CountFix(fixableArea);
                }
            }
        }
    }

    private void FixWithGrinding(FixableArea fixableArea)
    {
        var player = GetComponent<Player>();
        if (player != null)
        {
            fixableArea.FixWithGrinding();
        }
    }

    private void FixWithGlue(FixableArea fixableArea)
    {
        var player = GetComponent<Player>();
        if (player != null)
        {
            var activeItem = player.InventoryUI.GetActiveItem();
            if (activeItem != null && activeItem.Type == Item.ItemType.Glue)
            {
                var glue = player.InventoryUI.GetItem(Item.ItemType.Glue);

                if (glue != null && glue.Amount > 0)
                {
                    fixableArea.FixWithGlue();
                    player.InventoryUI.UseInventoryItem(glue);
                }
                else
                {
                    // show noodle warning
                }
            }
        }
    }

    private void FixWithNoodles(FixableArea fixableArea)
    {
        var player = GetComponent<Player>();
        if (player != null)
        {
            var activeItem = player.InventoryUI.GetActiveItem();
            if (activeItem != null && activeItem.Type == Item.ItemType.Noodle)
            {
                var noodle = player.InventoryUI.GetItem(Item.ItemType.Noodle);

                if (noodle != null && noodle.Amount > 0)
                {
                    fixableArea.FixWithNoodles();
                    player.InventoryUI.UseInventoryItem(noodle);
                }
                else
                {
                    // show noodle warning
                }
            }
        }
    }
}