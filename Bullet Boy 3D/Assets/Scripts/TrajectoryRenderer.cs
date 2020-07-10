using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TrajectoryRenderer : MonoBehaviour
{

    private LineRenderer lineRendererComponent;

    private void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
      
    }



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





