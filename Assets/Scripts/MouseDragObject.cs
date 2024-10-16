using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MouseDragObject : MonoBehaviour

{
    private Vector3 mOffset;
    private float mZCoord;


    void OnMouseDown()

    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }



    private Vector3 GetMouseAsWorldPoint()

    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;


        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


    void OnMouseDrag()

    {
        Vector3 objectPos = GetMouseAsWorldPoint() + mOffset;
        objectPos.y = 0.1f;
        transform.position = objectPos;
    }


    //마우스로 해도 모바일에선 터치로 작동되나? 왜 되지
}