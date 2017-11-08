using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Telephony;


namespace MakeCall
{
    [Activity(Label = "MakeCall", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button btnCall = FindViewById<Button>(Resource.Id.btn_call);

            btnCall.Click += delegate {
                //uniform resource identifier
                var uri = Android.Net.Uri.Parse("tel:6479697979");
                var callIntent = new Intent(Intent.ActionDial, uri);
                //var callIntent = new Intent(Intent.ActionCall, uri);
                StartActivity(callIntent);
            };

            Button btnSms = FindViewById<Button>(Resource.Id.btn_sms);

            btnSms.Click += delegate {

                EditText txtMsg = FindViewById<EditText>(Resource.Id.txt_msg);

                var smsUri = Android.Net.Uri.Parse("smsto:6479697979");
                var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                smsIntent.PutExtra("sms_body", txtMsg.Text);
                StartActivity(smsIntent);

            };

            Button btnEmail = FindViewById<Button>(Resource.Id.btn_email);

            btnEmail.Click += delegate {
                Toast.MakeText(this, "Test", ToastLength.Long).Show();

                var email = new Intent(Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { "arkiz79@gmail.com", "drew.kiyoung.park@gmail.com" });
                email.SetType("message/rfc822");
                StartActivity(email);
               
                /*
                 * var email = new Intent(Android.Content.Intent.ActionSend);
                    email.SetType("message/rfc822");
                    StartActivity(email);

                email.PutExtra(Android.Content.Intent.ExtraEmail
                               , new string[] { "arkiz79@gmail.com", "drew.kiyoung.park@gmail.com"});

                email.PutExtra(Android.Content.Intent.ExtraCc, new string[] { "kukune@naver.com" });

                email.PutExtra(Android.Content.Intent.ExtraSubject, "test email");

                email.PutExtra(Android.Content.Intent.ExtraText, "This is test messaage.");

                email.SetType("message/rfc822");
*/

                
                
            };
        }
    }
}

