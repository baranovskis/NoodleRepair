using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    private bool _isOpen = false;
    private bool _rotating = false;

    public override void Interact()
    {
        if (_rotating)
        {
            return;
        }

        _isOpen = !_isOpen;

        if (_isOpen)
        {
            StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
        }
        else if (!_isOpen)
        {
            StartCoroutine(RotateMe(Vector3.down * 90, 0.8f));
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        _rotating = true;
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        _rotating = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //var rotation = gameObject.transform.rotation.eulerAngles;

        //if (_isOpen && gameObject.transform.rotation.y < 90)
        //{
        //    gameObject.transform.rotation.eulerAngles = 
        //        new Quaternion(rotation.x, rotation.y + 1, rotation.z, rotation.w);
        //}
        //else if (!_isOpen && gameObject.transform.rotation.y > 0)
        //{
        //    gameObject.transform.rotation =
        //        new Quaternion(rotation.x, rotation.y - 1, rotation.z, rotation.w);
        //}
    }
}
