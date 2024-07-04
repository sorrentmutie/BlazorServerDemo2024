using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDemoComponentsLibrary.Interop;

public class MapMarker
{
    public double Lat { get; set; }
    public double Lng { get; set; }
    public string PopupContent { get; set; } = "Title";
}
