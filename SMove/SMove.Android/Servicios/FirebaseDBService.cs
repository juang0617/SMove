using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Auth;
using Android.App;
using Android.Content;
using Firebase.Database;
using SMove.Droid.Servicios;
using System.Collections.ObjectModel;
using System.Linq;
using SMove.Services;

[assembly: Dependency(typeof(FirebaseDBService))]
namespace SMove.Droid.Servicios
{
    public class ValueEventListener : Java.Lang.Object, IValueEventListener
    {
        public void OnCancelled(DatabaseError error) { }

        public void OnDataChange(DataSnapshot snapshot)
        {
            String message = snapshot.Value.ToString();
            MessagingCenter.Send(FirebaseDBService.KEY_MESSAGE, FirebaseDBService.KEY_MESSAGE, message);
        }
    }

    public class FirebaseDBService : IFirebaseDBService
    {
        DatabaseReference databaseReference;
        FirebaseDatabase database;
        FirebaseAuthService authService = new FirebaseAuthService();
        public static String KEY_MESSAGE = "items";

        public void Connect()
        {
            database = FirebaseDatabase.GetInstance(MainActivity.app);
        }

        public void GetMessage()
        {
            var userId = authService.GetUserId();
            databaseReference = database.GetReference("items/" + userId);
            databaseReference.AddValueEventListener(new ValueEventListener());
        }

        public string GetMessageKey()
        {
            return KEY_MESSAGE;
        }

        public void SetMessage(string message)
        {
            var userId = authService.GetUserId();
            databaseReference = database.GetReference("items/" + userId);

            String key = databaseReference.Push().Key;

            databaseReference.Child(key).SetValue(message);
        }

        public void DeleteItem(string key)
        {
            var userId = authService.GetUserId();
            databaseReference = database.GetReference("items/" + userId);
            databaseReference.Child(key).RemoveValue();
        }
    }
}