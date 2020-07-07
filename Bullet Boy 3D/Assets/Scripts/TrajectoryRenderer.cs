using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TrajectoryRenderer : MonoBehaviour
{
//     public Transform point1;
//     public Transform point2;
//     public Transform point3;
    private LineRenderer lineRendererComponent;
//     public int vertexCount = 12;

//     //private float gravityScale = 1;

//    // float rotationSpeed = 500;

    private void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
      
    }

//     void Update()
//     {
//         var pointList = new List<Vector3>();
//         for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
//          {
//             var tangentLineVertex1 = Vector3.Lerp(point1.position,point2.position,ratio);
//             var tangentLineVertex2 = Vector3.Lerp(point2.position, point3.position,ratio);
//             var bezierPoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
//             pointList.Add(bezierPoint);
//          }
//          lineRenderer.positionCount = pointList.Count;
//         lineRenderer.SetPositions(pointList.ToArray());
//     }

//     void OnDrawGizmos()
//     {
//         Gizmos.color = Color.green;
//         Gizmos.DrawLine(point1.position, point2.position);

//         Gizmos.color = Color.cyan;
//         Gizmos.DrawLine(point2.position, point3.position);

//          Gizmos.color = Color.red;
//          for (float ratio = 0.5f / vertexCount; ratio < 1; ratio += 1.0f / vertexCount)
//          {
//             Gizmos.DrawLine(Vector3.Lerp(point1.position,point2.position,ratio),
//                  Vector3.Lerp(point2.position, point3.position,ratio));
//          }


//     }




    // private void Update()
    // {
    //     if (Input.GetMouseButton(0))
    //    {
          
    //     transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotationSpeed * Time.deltaTime);

    //     if(transform.rotation.y > 0)
    //     {
    //         gravityScale = -1;
    //     }
    //     else 
    //     {
    //         gravityScale = 1;
    //     }
           

    //   }

    //   Physics.gravity = new Vector3(gravityScale, 0, 0);

    // }

    public void ShowTrajectory(Vector3 origin, Vector3 speed) // принимает откуда вылетает пуля и с какой скоростью
    {
        
        Vector3[] points = new Vector3[100]; // массив точек
        lineRendererComponent.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++) //рассчитываем положение точек
        {
            float time = i * 0.1f; // в какой момент после запуска мы рассчитываем точку 

            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;

            if(points[i].z > origin.z + 5)
            {
                lineRendererComponent.positionCount = i+1;
                break;
            }
        }

        lineRendererComponent.SetPositions(points);
    }
}





// using UnityEngine;

// public class TrajectoryRenderer : MonoBehaviour
// {
//     private LineRenderer lineRendererComponent;

//     private void Start()
//     {
//         lineRendererComponent = GetComponent<LineRenderer>();
//     }

//     public void ShowTrajectory(Vector3 origin, Vector3 speed)
//     {
//         Vector3[] points = new Vector3[100];
//         lineRendererComponent.positionCount = points.Length;

//         for (int i = 0; i < points.Length; i++)
//         {
//             float time = i * 0.1f;

//             points[i] = origin + speed * time + Physics.gravity * time * time / 2f;

//             if(points[i].y < 0)
//             {
//                 lineRendererComponent.positionCount = i+1;
//                 break;
//             }
//         }

//         lineRendererComponent.SetPositions(points);
//     }
//}