using System.Collections;
using UnityEngine;

public class MouseDrawing : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Color lineColor;

    private bool isDrawing;//нужен для понимания рисуем ли мы в даннй момент (нажата ли кнопка)

    private void Awake()
    {
        lineRenderer.material.color = lineColor; //присваиваем линии нужный цвет
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //если клавиша нажата
        {
            isDrawing = true; //мы рисуем 
            lineRenderer.positionCount = 0; //сбрасиываем предыдущую нарисованную линию (обнуляем кол-во точек)
        }
        else if (Input.GetMouseButtonUp(0)) //если отпускаем клавишу то не рисуем
        {
            isDrawing = false; //не рисуем
        }

        if (isDrawing) //если рисуем, то рисуем =)
        {
            Drawing();
        }
    }

    private void Drawing()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //создаем луч
        
        if (Physics.Raycast(ray, out RaycastHit hit)) //попали лучем и забрали инфу
        {
            Vector3 mousePosition = hit.point;//снимаем точку в которую попали

            if (lineRenderer.positionCount == 0) //если пока нет точек
            {
                lineRenderer.positionCount = 1;//то создаем первую
                lineRenderer.SetPosition(lineRenderer.positionCount-1, mousePosition); //сетим точку в текущую точку мышки
            }
            else //если уже есть точки в линии, то
            {
                lineRenderer.positionCount++; //увеличиваем кол-во точек 
                lineRenderer.SetPosition(lineRenderer.positionCount-1, mousePosition);//сетим в текущую точку линии в новую точку -1 так как это индекс
            }
        }
    }
}

