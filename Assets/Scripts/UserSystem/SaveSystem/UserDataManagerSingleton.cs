using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RotaryPong
{
    public class UserDataManagerSingleton : MonoBehaviour
    {

        public static UserDataManagerSingleton Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
            DontDestroyOnLoad(Instance);
        }

        int userID = 0;
        public void SetUserID(int id)
        {
            if(id <= 3 && id > 0)
            {
                userID = id;
            }
            else
            {
                userID = 0;
            }
        }

        public SaveSheet loadedFile;

        public void LoadSavefile()
        {
            SaveSystem saveSystem = new SaveSystem();
            string _jsonID = userID.ToString();
            loadedFile = saveSystem.LoadSheet(_jsonID);
        }

        public void SaveSavefile()
        {
            string jsonID = userID.ToString();
            SaveSystem saveSystem = new SaveSystem();
            SaveSheetStruct sheetStruct = new SaveSheetStruct(loadedFile.ACHIEVEMENT_TYPEA);
            saveSystem.SaveSheet(sheetStruct, jsonID);
        }

        public bool CheckForSavefile(int userID)
        {
            SaveSystem saveSystem = new SaveSystem();
            string _jsonID = userID.ToString();
            SaveSheet tempFile = saveSystem.LoadSheet(_jsonID);

            if(tempFile == null) { return false; }
            else { return true;  }
        }
    }
}
