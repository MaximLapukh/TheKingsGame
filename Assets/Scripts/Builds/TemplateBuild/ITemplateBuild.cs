using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface ITemplateBuild
{
    public bool CanBuildHere();
    public void Destroy();
    public void SetPosition(Vector3 vec);
    //GetOffset() in future
}

