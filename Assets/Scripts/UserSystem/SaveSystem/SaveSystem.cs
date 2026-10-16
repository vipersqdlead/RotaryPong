using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SaveSystem
{
    public const string saveSheetKey ="saveSheetKey";
    
    public void SaveSheet(SaveSheetStruct saveSheetStruct, string id)
    {
        //Inicializar un nuevo pjSheet con los valores de nuestras variables
        SaveSheet pjSheet = new SaveSheet(saveSheetStruct);

        //Estamos convirtiendo la clase a JSON que es siempre de tipo string
        string data = JsonUtility.ToJson(pjSheet);

        //Estamos guardando el json en player prefs
        PlayerPrefs.SetString(saveSheetKey + id, data);
    }

    public SaveSheet LoadSheet(string id)
    {
        //Recuperando el json mediante playerPrefs
        string data = PlayerPrefs.GetString(saveSheetKey + id, "NULL");

        if (data == "NULL")
        {
            Debug.Log("Data not found");
            return null;
        }

        //Estamos convirtiendo el Json recuperado a su clase original y guardamos la info en pjSheet
        SaveSheet pjSheet = JsonUtility.FromJson<SaveSheet>(data);

        return pjSheet;

    }
}
