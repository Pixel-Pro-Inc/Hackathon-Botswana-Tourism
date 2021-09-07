using Assets.Scripts.Entities;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class FireBaseHelper : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEvent OnFirebaseInitialized = new UnityEvent();
    FirebaseApp app = FirebaseApp.DefaultInstance;
    private FirebaseDatabase _database;
    private Firebase.Auth.FirebaseAuth auth= Firebase.Auth.FirebaseAuth.DefaultInstance;
    Users loadeduser;


    void Start()
    {
        #region Google play services version confirmaation

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available) //Doen't seem like we actually need this cause of the method below this one
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
       
        _database = FirebaseDatabase.DefaultInstance;

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception!=null)
            {
                Debug.LogError($"Failed to initialize  Firebase with {task.Exception}");
                return;
            }
        });
        InitializeFireBase();
        OnFirebaseInitialized.Invoke();
    }
    void Update()
    {
        
    }

    #region Initialise FireBase
    private void InitializeFireBase()
    {
        //app.SetEditorDatabaseUrl("https://hackathon-botswana-tourism-default-rtdb.firebaseio.com");
        app.Options.DatabaseUrl =new Uri("https://hackathon-botswana-tourism-default-rtdb.firebaseio.com/");
        Debug.Log("The url has been set and database finnessed");
    }
    #endregion
    #region Set User
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
    #endregion
    #region  Collect user
    public async void LoadUser(string userId)
    {
        var datasnap = await _database.GetReference(userId).GetValueAsync();
        if (datasnap.Exists)
            loadeduser = (Users)JsonUtility.FromJson<Users>(_database.GetReference(userId).Key);
    }
    public Users GetLoadedUser(string userId)
    {
        LoadUser(userId);
        return loadeduser;
    }
    #endregion
    #region Erase user

    public void EraseUser(string userid)
    {
        _database.GetReference(userid).RemoveValueAsync();
    }
    #endregion

    #region Authentication
    public void AnonymousAuthent()
    {
        auth.SignInAnonymouslyAsync().ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAnonymouslyAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }
    public void EmailAuthent()
    {
        auth.CreateUserWithEmailAndPasswordAsync(loadeduser.username, loadeduser.useremail).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            writeNewUser(newUser.UserId, newUser.DisplayName, newUser.Email);
        });
    }
    #endregion
    public void SignIn()
    {
        auth.SignInWithEmailAndPasswordAsync(loadeduser.useremail, loadeduser.userpassword).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            GetLoadedUser(newUser.UserId);
        });
    }
}
