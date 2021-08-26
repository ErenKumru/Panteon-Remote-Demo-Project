using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterController : MonoBehaviour
{
    [SerializeField] private Camera painterCamera;
    [SerializeField] private GameObject brush;
    [SerializeField] private GameObject paintableObject;

    private LineRenderer lineRenderer;
    private Vector3 lastPosition;
    private PaintableController paintableController;

    private void Awake()
    {
        paintableController = FindObjectOfType<PaintableController>();
    }

    private void Update()
    {
        Paint();
    }

    private void Paint()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateBrush();
        }

        if(Input.GetMouseButton(0))
        {
            Ray ray = painterCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(painterCamera.transform.position, ray.direction * 30f, Color.green);

            //check if ray hit
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit))
            {
                //check if ray is at the same position
                Vector3 currentPos = rayHit.point;
                if (lineRenderer != null && currentPos != lastPosition && Vector3.Distance(currentPos, lastPosition) > 0.1f /*&& CandAddPoint(rayHit.point)*/)
                {
                    AddPoint(currentPos);
                    lastPosition = currentPos;
                }
            }
        }
        else
        {
            lineRenderer = null;
        }
    }

    private void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        lineRenderer = brushInstance.GetComponent<LineRenderer>();

        Ray ray = painterCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(painterCamera.transform.position, ray.direction, Color.green, 100f);

        //check if ray hit
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit) /*&& CandAddPoint(rayHit.point)*/)
        {
            lineRenderer.SetPosition(0, rayHit.point);
            lineRenderer.SetPosition(1, rayHit.point);
        }
    }

    private void AddPoint(Vector3 pointPosition)
    {
        if(lineRenderer.positionCount == 0)
        {
            lineRenderer.SetPosition(0, pointPosition);
            lineRenderer.SetPosition(1, pointPosition);

        }
        else
        {
            lineRenderer.positionCount++;
            int positionIndex = lineRenderer.positionCount - 1;
            lineRenderer.SetPosition(positionIndex, pointPosition);
            paintableController.AddPaintedPosition(pointPosition);
        }
    }


    //Should work but line renderer draws lines from (0,0,0) to next position when the starting point is in range of painted position. Don't know why.
    //private bool CandAddPoint(Vector3 currentPosition)
    //{
    //    if (paintableController != null)
    //    {
    //        List<Vector3> paintedPositions = paintableController.GetPaintedPositions();

    //        if (paintedPositions != null)
    //        {
    //            if (paintedPositions.Count == 0) return true;

    //            foreach (Vector3 paintedPosition in paintedPositions)
    //            {
    //                if (Vector3.Distance(currentPosition, paintedPosition) < 0.1f)
    //                {
    //                    return false;
    //                }
    //            }
    //        }
    //    }

    //    return true;
    //}
}
