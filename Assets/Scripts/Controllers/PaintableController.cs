using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableController : MonoBehaviour
{
    [SerializeField] private float width;
    [SerializeField] private float height;
    [SerializeField] private float checkDistance;
    private float surfaceArea; //The difference between RealArea and manually CalculatedArea is 314,5172 - 314,496 = 0,0212 which can or cannot be ignored
    private float paintedPercentage;

    private List<Vector3> paintedPositions = new List<Vector3>();

    private void Awake()
    {
        CalculatePaintableArea();
    }

    //Calculates area defined by the world coordinates of the mesh. Width and height values are measured through raycast. CalculatedArea = 314,496
    private void CalculatePaintableArea()
    {
        surfaceArea = width * height;
        surfaceArea /= 0.1f;
    }

    public void AddPaintedPosition(Vector3 position)
    {
        if (paintedPositions != null && Mathf.Abs(position.z - checkDistance) < 0.1f)
        {
            if (paintedPositions.Count == 0) paintedPositions.Add(position);
            else
            {
                bool canAdd = true;

                foreach (Vector3 paintedPosition in paintedPositions)
                {
                    if (Vector3.Distance(position, paintedPosition) < 0.1f)
                    {
                        canAdd = false;
                    }
                }

                if (canAdd) paintedPositions.Add(position);
            }
        }
    }

    //public List<Vector3> GetPaintedPositions()
    //{
    //    return paintedPositions;
    //}

    private float CalculatePaintedPercentage()
    {
        return (paintedPositions.Count / surfaceArea * 100f);
    }

    public float GetPaintedPercentage()
    {
        paintedPercentage = CalculatePaintedPercentage();
        return paintedPercentage;
    }

    //Calculates real surface area of the surface that is looking towards to camera. RealArea = 314,5172
    //private float CalculateFacingArea(Mesh mesh, Vector3 direction)
    //{
    //    direction = direction.normalized;
    //    var triangles = mesh.triangles;
    //    var vertices = mesh.vertices;

    //    double sum = 0.0;

    //    for (int i = 0; i < triangles.Length; i += 3)
    //    {
    //        Vector3 corner = vertices[triangles[i]];
    //        Vector3 a = vertices[triangles[i + 1]] - corner;
    //        Vector3 b = vertices[triangles[i + 2]] - corner;

    //        float projection = Vector3.Dot(Vector3.Cross(b, a), direction);
    //        if (projection > 0f)
    //            sum += projection;
    //    }

    //    return (float)(sum / 2.0);
    //}
}
