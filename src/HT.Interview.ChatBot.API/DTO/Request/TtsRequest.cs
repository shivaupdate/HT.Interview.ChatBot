namespace HT.Interview.ChatBot.API.DTO.Request
{
    /// <summary>
    /// The tts endpoint is used to perform text-to-speech - generate speech (audio file) from text.
    /// </summary>
    public class TtsRequest  
    {  
        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; } 
    }
}
