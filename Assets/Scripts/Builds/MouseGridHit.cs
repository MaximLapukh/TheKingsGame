using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MouseGridHit
{
    private LayerMask groundMask;
    private Vector3 lastPoint;

    private float sizeCell;
    public MouseGridHit(LayerMask ground_mask, float size_cell)
    {
        groundMask = ground_mask;
        sizeCell = size_cell;
    }

    public Vector3 GetMouseHit() //bad code, because you perhaps want to use touch instead of mouse position
    {        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 20, groundMask))
        {
            lastPoint = LinkToGrid(hit);
        }
        return lastPoint;
    }

    private Vector3 LinkToGrid(RaycastHit hit)
    {
        var point = hit.point;

        //link to grid
        int count_cell_x = (int)(point.x / sizeCell);
        point.x = count_cell_x * sizeCell;
        int count_cell_z = (int)(point.z / sizeCell);
        point.z = count_cell_z * sizeCell;

        //calculate and add remains to point
        var remains_x = Math.Round((hit.point.x % sizeCell) / sizeCell) * sizeCell;
        point.x += (float)remains_x;
        var remains_z = Math.Round((hit.point.z % sizeCell) / sizeCell) * sizeCell;
        point.z += (float)remains_z;

        //idea: add point.y in future
        return point;
    }
}

