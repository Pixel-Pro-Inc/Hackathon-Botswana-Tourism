using Assets.Scripts.Entities;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseHelper : MonoBehaviour
{
    // Start is called before the first frame update
    DatabaseReference reference;
    void Start()
    {
        #region Google play services version confirmaation

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

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
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void writeNewUser(string userId, string name, string email)
    {
        Users user = new Users(name, email);
        string json = JsonUtility.ToJson(user);

        reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }
    private void updateExistingUser(string userId, string record, string detail)
    {
        reference.Child("users").Child(userId).Child(record).SetValueAsync(detail);
    }
}
