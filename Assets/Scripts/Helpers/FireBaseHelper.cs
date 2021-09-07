using Assets.Scripts.Entities;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class FireBaseHelper : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEvent OnFirebaseInitialized = new UnityEvent();
    private FirebaseDatabase _database;


    void Start()
    {
        #region Google play services version confirmaation

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available) //Doen't seem like we actually need this cause of the method below this one
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //app = Firebase.FirebaseApp.DefaultInstance; 

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
        #endregion
       
        _database = FirebaseDatabase.DefaultInstance;

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception!=null)
            {
                Debug.LogError($"Failed to initialize  Firebase with {task.Exception}");
                return;
            }
        });
        OnFirebaseInitialized.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void writeNewUser(string userId, string name, string email)
    {
        Users user = new Users(name, email);
        string json = JsonUtility.ToJson(user);

        _database.RootReference.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }
    private void updateExistingUser(string userId, string record, string detail)
    {
        _database.RootReference.Child("users").Child(userId).Child(record).SetValueAsync(detail);
    }

    public async Task<bool> SaveExists(string userId)
    {
        var datasnap = await _database.GetReference(userId).GetValueAsync();
        return datasnap.Exists;
    }

    public async Users LoadUser(string userId)
    {
        var datasnap = await _database.GetReference(userId).GetValueAsync();
        if (!datasnap.Exists)
        {
            return null;
        }
        return JsonUtility.FromJson<Users>();
    }
}
