using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public class FBInit : MonoBehaviour {

    DatabaseReference mDatabaseRef;

    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unknown-cec43.firebaseio.com/");

        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        WriteNewUser("0000", "wonsangL", "harryandws@gmail.com");
    }

    private void WriteNewUser(string userId, string name, string email)
    {
        User user = new User(name, email);
        string json = JsonUtility.ToJson(user);

        mDatabaseRef.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }

}

public class User
{
    public string username;
    public string email;

    public User()
    {
    }

    public User(string username, string email)
    {
        this.username = username;
        this.email = email;
    }
}
