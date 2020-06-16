using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace BlazorChartist
{
  public class Series : ComponentBase, IDisposable
  {
    [Parameter] public string Name { get; set; }
    [Parameter] public IEnumerable<double> Values { get; set; }

    private readonly SeriesData seriesData = new SeriesData();

    protected override void OnParametersSet() {
        seriesData.Name = Name;
        seriesData.Data = Values;
    }
    
    [CascadingParameter] public Chart Parent { get; set; }
    
    protected override void OnInitialized() => Parent.Data.Series.Add(seriesData);
    
    public void Dispose() => Parent.Data.Series.Remove(seriesData);
  }
}