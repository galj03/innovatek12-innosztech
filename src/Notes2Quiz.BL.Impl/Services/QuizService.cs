using Notes2Quiz.BL.Models;
using Notes2Quiz.BL.Services;
using OpenAI;
using OpenAI.Chat;
using System.Runtime.CompilerServices;

namespace Notes2Quiz.BL.Impl.Services
{
    internal class QuizService : IQuizService
    {
        private readonly ChatClient _chatClient;

        public QuizService()
        {
            var client = new OpenAIClient("TODO: api key");
            _chatClient = client.GetChatClient("gpt-4o");//TODO: const
        }

        public async Task<string> DummyMethod(string input)
        {
            await Task.Run(() => { Thread.Sleep(1000); });
            var result = $"Hello, {input}!";
            return result;
        }

        public async Task<IQuiz> GenerateQuizFromText(string input, string quizName = "")
        {
            //TODO: if quizName is null or whitespace, then generate a name for it
            var prompt = FormattableStringFactory.Create("TODO: format", input);
            var completion = await _chatClient.CompleteChatAsync(prompt.ToString());
            var resultString = completion.Value.Content[0].Text;
            //TODO: process result
                //in a private method, which returns questions
            throw new NotImplementedException();
        }
    }
}
