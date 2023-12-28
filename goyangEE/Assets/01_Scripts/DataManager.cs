using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public List<Dictionary<string, object>> dataJWS;

    private void Start()
    {
        dataJWS = CSVReader.Read("DescriptionJWS");
    }
}
