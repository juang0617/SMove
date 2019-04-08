﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Gms.Common.Apis;
using Android.Gms.Common;
using System.Threading.Tasks;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Auth.Api;
using Firebase.Auth;

namespace SMove.Droid
{
    [Activity(Label = "GoogleLogin", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    public class GoogleLoginActivity : AppCompatActivity, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        const string TAG = "GoogleLoginActivity";

        const int RC_SIGN_IN = 9001;

        const string KEY_IS_RESOLVING = "is_resolving";
        const string KEY_SHOULD_RESOLVE = "should_resolve";

        static GoogleApiClient mGoogleApiClient;

        bool mIsResolving = false;

        bool mShouldResolve = false;

        private static GoogleSignInAccount mAuth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            String token = "745578531830-t2k4mc0gepe64h0ad6iolo2svgjaoa7n.apps.googleusercontent.com";
            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn).RequestIdToken(token).Build();

            mGoogleApiClient = new GoogleApiClient.Builder(this)
            .AddConnectionCallbacks(this)
            .AddOnConnectionFailedListener(this)
            .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
            .Build();

            Intent signInIntent = Auth.GoogleSignInApi.GetSignInIntent(mGoogleApiClient);
            StartActivityForResult(signInIntent, RC_SIGN_IN);
        }

        private void HandleResult(GoogleSignInAccount result)
        {
            if (result != null)
            {
                Intent myIntent = new Intent(this, typeof(GoogleLoginActivity));
                myIntent.PutExtra("result", result);
                SetResult(Result.Ok, myIntent);
            }
            Finish();
        }

        private async void UpdateData(bool isSignedIn)
        {
            if (isSignedIn)
            {
                HandleResult(mAuth);
            }
            else
            {
                await System.Threading.Tasks.Task.Delay(2000);
                mShouldResolve = true;
                mGoogleApiClient.Connect();
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            mGoogleApiClient.Connect();
        }

        protected override void OnStop()
        {
            base.OnStop();
            mGoogleApiClient.Disconnect();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutBoolean(KEY_IS_RESOLVING, mIsResolving);
            outState.PutBoolean(KEY_SHOULD_RESOLVE, mIsResolving);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == RC_SIGN_IN)
            {
                var result = Android.Gms.Auth.Api.Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                if (result.IsSuccess)
                {
                    // Google Sign In was successful, authenticate with Firebase
                    HandleResult(result.SignInAccount);

                }
                else
                {
                    // Google Sign In failed, update UI appropriately
                    HandleResult(null);
                }
            }
        }

        public void OnConnected(Bundle connectionHint)
        {
            UpdateData(false);
        }

        public void OnConnectionSuspended(int cause) { }

        public void OnConnectionFailed(ConnectionResult result)
        {
            if (!mIsResolving && mShouldResolve)
            {
                if (result.HasResolution)
                {
                    try
                    {
                        result.StartResolutionForResult(this, RC_SIGN_IN);
                        mIsResolving = true;
                    }
                    catch (IntentSender.SendIntentException e)
                    {
                        mIsResolving = false;
                        mGoogleApiClient.Connect();
                    }
                }
                else
                {
                    ShowErrorDialog(result);
                }
            }
            else
            {
                UpdateData(false);
            }
        }

        class DialogInterfaceOnCancelListener : Java.Lang.Object, IDialogInterfaceOnCancelListener
        {
            public Action<IDialogInterface> OnCancelImpl { get; set; }

            public void OnCancel(IDialogInterface dialog)
            {
                OnCancelImpl(dialog);
            }
        }

        void ShowErrorDialog(ConnectionResult connectionResult)
        {
            int errorCode = connectionResult.ErrorCode;

            if (GoogleApiAvailability.Instance.IsUserResolvableError(errorCode))
            {

                var listener = new DialogInterfaceOnCancelListener();
                listener.OnCancelImpl = (dialog) =>
                {

                    mShouldResolve = false;
                };
                GoogleApiAvailability.Instance.GetErrorDialog(this, errorCode, RC_SIGN_IN, listener).Show();
            }
            else
            {
                mShouldResolve = false;
            }
            HandleResult(mAuth);
        }
    }
}