using System.Collections.Generic;
using UnityEngine;

public static class LineRendererExtentions
{
    public static void Clear(this LineRenderer lineRenderer)
    {
        lineRenderer.positionCount = 0;
    }

    public static void SetPositions(this LineRenderer lineRenderer, List<Vector3> vectors)
    {
        lineRenderer.SetPositions(vectors.ToArray());
    }
}
