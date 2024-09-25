
using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using System.Diagnostics;
using System.IO;
using DI = System.Diagnostics;



public class StartPy : MonoBehaviour
{
    public static StartPy Instance;

    private string url = "http://localhost:5000/api/CSIIMNIKASTART";
    public bool Startbool;
    
   
    
    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        
        print(Application.dataPath);
        print(Application.dataPath + "\\Resource\\Start\\StartPy.exe");
        var directoryPath = new DirectoryInfo(Application.dataPath + "/Resources/Start/");

        if (directoryPath.Exists)
        {
            string savedFilePath = "StartPy" + ".exe";
            string AllPath = directoryPath + savedFilePath;
            //Debug.Log(AllPath);
            if (File.Exists(AllPath))
            {
                print("파일 있음,실행");
                Process.Start(Application.dataPath + "\\Resources\\Start\\StartPy.exe");
            }
        }

    }

    private void OnApplicationQuit()
    {
        Disable_Py();
    }

    void Start()
    {
        //string single_param = "9-3 DIVIDE  {1} over {3}+1=?";
        
        //StartCoroutine(CallPythonScript(single_param));
        //print("실행");

    }

    public void Disable_Py()
    {
        var processList = DI.Process.GetProcessesByName("StartPy");
        if(processList.Length > 0)
        {
            print("프로세스가 1개이상 동작중..");
            
            foreach(Process process in processList)
            {
                if (process.ProcessName.StartsWith("StartPy"))
                {
                    process.Kill();
                }
            }
        }
        else
        {
            print("실행된 프로세스 없음");
        }
    }
    private void Update()
    {
        if (Startbool)
        {
            Startbool = false;
            Disable_Py();
        }
    }


    [System.Serializable]
    public class RequestData
    {
        public string param;
    }
    IEnumerator CallPythonScript(string single_param)
    {
        
        RequestData requestData = new RequestData { param = single_param };
        string json = JsonUtility.ToJson(requestData);
        // json에서 'param' 키가 들어간 것을 확인하세요.
        print($"Sending JSON data: {json}");
        using UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer(); 
        request.SetRequestHeader("Content-Type", "application/json");
        
        yield return request.SendWebRequest();
        
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            print("Error: " + request.error);
        }
        else
        {
            print(request.downloadHandler.text.Replace("\\\\", "\\").Replace("\"",""));
            print("Received: " + request.downloadHandler.text);
        }
    }
    
    

}
