using Android.App;
using Android.Content;
using Android.OS;
using Android.Speech;
using Huawei.Hms.Mlsdk.Asr;
using MLKit.Droid.Renderers;
using MLKit.Models;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(SpeechToTextRenderer))]
namespace MLKit.Droid.Renderers
{
    public class SpeechToTextRenderer : ISpeechToText
    {
        private MLAsrRecognizer _speechRecognizer;
        private Activity _activity;

        public SpeechToTextRenderer()
        {
            _activity = CrossCurrentActivity.Current.Activity;
            _speechRecognizer = MLAsrRecognizer.CreateAsrRecognizer(_activity);
            _speechRecognizer.SetAsrListener(new SpeechRecognitionListener());
        }

        public void StartSpeechToText()
        {
            Intent intentSdk = new Intent(RecognizerIntent.ActionRecognizeSpeech)
                .PutExtra(MLAsrConstants.Language, "en-US")
                .PutExtra(MLAsrConstants.Feature, MLAsrConstants.FeatureAllinone);
            _speechRecognizer.StartRecognizing(intentSdk);
        }

        public void StopSpeechToText()
        {
            if (_speechRecognizer != null)
                _speechRecognizer.Destroy();
        }
    }

    public class SpeechRecognitionListener : Java.Lang.Object, IMLAsrListener
    {
        public void OnError(int error, string errorMessage)
        {
            // Called when an error occurs in recognition.
        }

        public void OnRecognizingResults(Bundle partialResults)
        {
            // Receive the recognized text from MLAsrRecognizer.
        }

        public void OnResults(Bundle results)
        {
            // Text data of ASR.
        }

        public void OnStartingOfSpeech()
        {
            // The user starts to speak, that is, the speech recognizer detects that the user starts to speak.
        }

        public void OnStartListening()
        {
            // The recorder starts to receive speech.
        }

        public void OnState(int state, Bundle bundle)
        {
            // Notify the app status change.
        }

        public void OnVoiceDataReceived(byte[] data, float energy, Bundle bundle)
        {
            // Return the original PCM stream and audio power to the user.
        }
    }
}
