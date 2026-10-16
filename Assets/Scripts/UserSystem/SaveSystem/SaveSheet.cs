using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //SIEMPRE QUE QUERAMOS CONVERTIR UNA CLASE A JSON NECESITA EL ATRIBUTO SERIALIZABLE
public class SaveSheet
{
    public int ACHIEVEMENT_TYPEA;

    public SaveSheet(SaveSheetStruct pjSheetStruct)
    {
        this.ACHIEVEMENT_TYPEA = pjSheetStruct.ACHIEVEMENT_TYPEA;
    }
}

public struct SaveSheetStruct
{
    public int ACHIEVEMENT_TYPEA;

    public SaveSheetStruct(int ACHIEVEMENT_1)
    {
        this.ACHIEVEMENT_TYPEA = ACHIEVEMENT_1;
    }
}
