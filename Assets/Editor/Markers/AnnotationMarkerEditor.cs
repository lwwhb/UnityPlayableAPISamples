using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine.Timeline;

[CustomTimelineEditor(typeof(AnnotationMarker))]
public class AnnotationMarkerEditor : MarkerEditor
{
    public override MarkerDrawOptions GetMarkerOptions(IMarker marker)
    {
        var annotation = marker as AnnotationMarker;
        if (annotation != null)
        {
            return new MarkerDrawOptions {
                tooltip = annotation.description
            };
        }
        return base.GetMarkerOptions(marker);
    }
}

