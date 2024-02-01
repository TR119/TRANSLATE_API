using Google.Api.Gax.Grpc.Rest;
using Google.Api.Gax.ResourceNames;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translate.V3;
using Grpc.Auth;
using TRANSLATE_API.Request;
using System.Net.WebSockets;

namespace TRANSLATE_API
{
    public class TranslateService
    {
        public async Task<TranslateTextResponse> TranslateText(TranslateRequest request, string path)
        {
            GoogleCredential credential;
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(TranslationServiceClient.DefaultScopes);
            }

            var client = new TranslationServiceClientBuilder
            {
                GrpcAdapter = RestGrpcAdapter.Default,
                ChannelCredentials = credential.ToChannelCredentials()
            }.Build();
            TranslateTextRequest requestToGoogle = new TranslateTextRequest
            {
                SourceLanguageCode = string.IsNullOrEmpty(request.SourceLanguageCode) ? request.SourceLanguageCode : "",
                Contents = { request.Contents },
                TargetLanguageCode = request.ContTargetLanguageCode,
                Parent = new ProjectName("translationapp-412104").ToString()
            };
            TranslateTextResponse response = client.TranslateText(requestToGoogle);

            return response;
            /*// response.Translations will have one entry, because request.Contents has one entry.
            Translation translation = response.Translations[0];
            Console.WriteLine($"Detected language: {translation.DetectedLanguageCode}");
            Console.WriteLine($"Translated text: {translation.TranslatedText}");*/
        }



    }
}
