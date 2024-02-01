namespace TRANSLATE_API.Request
{
    public class TranslateRequest
    {
        public string Contents { get; set; }
        public string ContTargetLanguageCode { get; set; }
        public string SourceLanguageCode { get; set; }  
    }
}
