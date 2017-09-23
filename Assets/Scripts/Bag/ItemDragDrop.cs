using UnityEngine;
using System.Collections;

public class ItemDragDrop : UIDragDropItem {

    protected override void OnDragDropStart()
    {
        base.OnDragDropStart();
        this.GetComponent<UIWidget>().depth += 2;
    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if (surface == null)
        {
            this.transform.parent = this.transform.parent;
            this.transform.localPosition = Vector3.zero;
            this.GetComponent<UIWidget>().depth -= 2;
            return;
        }
        if (surface.tag == "Cell")
        {
            this.transform.parent = surface.transform;
            this.transform.localPosition = Vector3.zero;
        }
        else if (surface.tag == "Item")
        {
            Transform parent = this.transform.parent;
            this.transform.parent = surface.transform.parent;
            this.transform.localPosition = Vector3.zero;
            surface.transform.parent = parent;
            surface.transform.localPosition = Vector3.zero;
        }
        this.GetComponent<UIWidget>().depth -= 2;
    }
}
