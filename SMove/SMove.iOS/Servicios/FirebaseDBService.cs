using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database;
using Foundation;
using SMove.iOS.Servicios;
using SMove.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseDBService))]
namespace SMove.iOS.Servicios
{
    public class FirebaseDBService : IFirebaseDBService
    {
        public static String KEY_MESSAGE = "items";

        private FirebaseAuthService authService = new FirebaseAuthService();
        DatabaseReference databaseReference;

        public void Connect()
        {
            databaseReference = Database.DefaultInstance.GetRootReference();
        }

        public void GetMessage()
        {
            var userId = authService.GetUserId();
            var messages = databaseReference.GetChild("items").GetChild(userId);

            nuint handleReference2 = messages.ObserveEvent(DataEventType.Value, (snapshot) =>
            {
                //var folderData = snapshot.GetValue();
                // Do magic with the folder data
                String message = "";
                if (snapshot.GetValue() != NSNull.Null)
                {
                    message = snapshot.GetValue().ToString();
                }
                MessagingCenter.Send(FirebaseDBService.KEY_MESSAGE, FirebaseDBService.KEY_MESSAGE, message);
            });
        }

        public void SetMessage(String message)
        {
            var userId = authService.GetUserId();
            var messages = databaseReference.GetChild("items").GetChild(userId).Reference;
            var key = messages.GetChildByAutoId().Key;
            messages.GetChild(key).SetValue((NSString)message);
        }

        public String GetMessageKey()
        {
            return KEY_MESSAGE;
        }

        public void DeleteItem(string key)
        {
            var userId = authService.GetUserId();
            var messages = databaseReference.GetChild("items").GetChild(userId).Reference;
            messages.GetChild(key).RemoveValue();
        }
    }
}