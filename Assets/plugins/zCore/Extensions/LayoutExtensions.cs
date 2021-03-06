﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class LayoutExtensions
{



    public static LayoutElement GetLayout(RectTransform rect)
    {
        LayoutElement le = null;
        LayoutGroup lg = rect.GetComponent<LayoutGroup>();
        if (lg != null)
        {
            le = rect.gameObject.AddComponent<LayoutElement>();

            le.flexibleHeight = 1;
            le.flexibleWidth = 1;
        }
        return le;
    }

    public static ContentSizeFitter AddContentSizeFitter(this RectTransform rect)
    {
        ContentSizeFitter c = rect.gameObject.AddOrGetComponent<ContentSizeFitter>();
        c.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        c.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        return c;
    }
    public static VerticalLayoutGroup ToVeritical(this HorizontalLayoutGroup layout)
    {

        RectOffset padding = layout.padding;
        float spacing = layout.spacing;
        bool childForceExpandHeight = layout.childForceExpandHeight;
        bool childForceExpandWidth = layout.childForceExpandWidth;
        bool childControlHeight = layout.childControlHeight;
        bool childControlWidth = layout.childControlWidth;
        GameObject g = layout.gameObject;
        GameObject.DestroyImmediate(layout);
        VerticalLayoutGroup ng = g.AddComponent<VerticalLayoutGroup>();
        
        ng.childForceExpandHeight = false;
        ng.childForceExpandWidth = false;
        ng.childControlHeight = true;
        ng.childControlWidth = true;
        ng.spacing = spacing;
        ng.padding = padding;
        return ng;
    }

    public static HorizontalLayoutGroup ToHorizontal(this VerticalLayoutGroup layout)
    {

        RectOffset padding = layout.padding;
        float spacing = layout.spacing;
        bool childForceExpandHeight = layout.childForceExpandHeight;
        bool childForceExpandWidth = layout.childForceExpandWidth;
        bool childControlHeight = layout.childControlHeight;
        bool childControlWidth = layout.childControlWidth;
        GameObject g = layout.gameObject;
        GameObject.DestroyImmediate(layout);
        HorizontalLayoutGroup ng = g.AddComponent<HorizontalLayoutGroup>();
        ng.childForceExpandHeight = false;
        ng.childForceExpandWidth = false;
        ng.childControlHeight = true;
        ng.childControlWidth = true;
        ng.spacing = spacing;
        ng.padding = padding;
        return ng;
    }
/*
public static float GetSpacing(this HorizontalLayoutGroup g)
{
    return g.spacing;
}
public static float GetSpacing(this VerticalLayoutGroup g)
{
    return g.spacing;
} */

    public static LayoutElement[] GetActiveLayoutElements(this GameObject g, bool includeInactive=false)
    {
        List<LayoutElement> elements = new List<LayoutElement>();
        //Debug.Log("seacrihg "+g.transform.childCount);
        //var les=g.Get
        for (int i = 0; i < g.transform.childCount; i++)
        {
            GameObject thisChild = g.transform.GetChild(i).gameObject;
            LayoutElement le = thisChild.GetComponent<LayoutElement>();
            if (le == null) 
              { 
                  Debug.Log(" NO LAYUT ELEMENT ON GAMEOBJECT " + thisChild.name, thisChild);
              }
            else
            {
         //       LayoutHelper lh = thisChild.GetComponent<LayoutHelper>();
           //     if (lh != null) Debug.Log("lh present");
                //else
               if (le.ignoreLayout==false)
                    elements.Add(le);
            }
        }

        return elements.ToArray();
    }

    public static LayoutElement[] GetActiveLayoutElementsOld(this GameObject g)
    {
        List<LayoutElement> elements = new List<LayoutElement>();
        //Debug.Log("seacrihg "+g.transform.childCount);
        for (int i = 0; i < g.transform.childCount; i++)
        {
            GameObject thisChild = g.transform.GetChild(i).gameObject;
            LayoutElement le = thisChild.GetComponent<LayoutElement>();
            if (le == null) 
              { 
                  Debug.Log(" NO LAYUT ELEMENT ON GAMEOBJECT " + thisChild.name, thisChild);
              }
            else
            {
         //       LayoutHelper lh = thisChild.GetComponent<LayoutHelper>();
           //     if (lh != null) Debug.Log("lh present");
                //else
               if (!le.ignoreLayout)
                    elements.Add(le);
            }
     
        }


        return elements.ToArray();
    }

    public static LayoutElement[] GetActiveElements(this VerticalLayoutGroup layout)
    {
        List<LayoutElement> elements = new List<LayoutElement>();
        if (layout == null) return elements.ToArray();
        for (int i = 0; i < layout.transform.childCount; i++)
        {
            GameObject thisChild = layout.transform.GetChild(i).gameObject;
            LayoutElement le = thisChild.GetComponent<LayoutElement>();
            if (le != null)
            {
                if (!le.ignoreLayout) elements.Add(le);
            }
        }
        return elements.ToArray();
    }


    public static LayoutElement[] GetActiveElements(this HorizontalLayoutGroup layout)
    {
        List<LayoutElement> elements = new List<LayoutElement>();
        if (layout == null) return elements.ToArray();
        for (int i = 0; i < layout.transform.childCount; i++)
        {
            GameObject thisChild = layout.transform.GetChild(i).gameObject;
            LayoutElement le = thisChild.GetComponent<LayoutElement>();
            if (le != null)
            {
                if (!le.ignoreLayout) elements.Add(le);
            }
        }
        return elements.ToArray();
    }
public static void SetChildControl(this HorizontalLayoutGroup layout, float spacing = 0)

{
    if (layout == null) return;
    layout.childForceExpandHeight = false;
    layout.childForceExpandWidth = false;
    layout.childControlHeight = true;
    layout.childControlWidth = true;
    layout.spacing = spacing;
}

public static void SetChildControl(this VerticalLayoutGroup layout, float spacing = 0)

{
    if (layout == null) return;
    layout.childForceExpandHeight = false;
    layout.childForceExpandWidth = false;
    layout.childControlHeight = true;
    layout.childControlWidth = true;
    layout.spacing = spacing;
}
public static void SetMargin(this HorizontalLayoutGroup layout, int margin = 0)

{
    if (layout == null) return;
    layout.padding = new RectOffset(margin, margin, margin, margin);
}

public static void SetMargin(this VerticalLayoutGroup layout, int margin = 0)

{
    if (layout == null) return;
    layout.padding = new RectOffset(margin, margin, margin, margin);
}



public static Image AddImageChild(this GameObject g, float opacity = 0.3f)
{
    Image image = g.AddComponent<Image>();
    image.color = new Color(Random.value * 0.3f + 0.7f,
         Random.value * 0.3f + 0.7f,
     Random.value * 0.2f, opacity);

    image.sprite = Resources.Load("Background") as Sprite;
    image.name = "Image";
    Debug.Log("added image to " + g.name, g);
    return image;
}

public static Image AddImageChild(this RectTransform rect, float opacity = 0.3f)
{
    return rect.gameObject.AddImageChild(opacity);
}

}
