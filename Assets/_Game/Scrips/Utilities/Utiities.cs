using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Utiities 
{
    //sap xep lai list
    public static List<T> SortOrder<T>(List<T> list, int amount)
    {
        return list.OrderBy(d => System.Guid.NewGuid()).Take(amount).ToList();
    }
}
