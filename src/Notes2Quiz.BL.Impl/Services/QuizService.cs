using Notes2Quiz.BL.Application;
using Notes2Quiz.BL.Models;
using Notes2Quiz.BL.Models.Factories;
using Notes2Quiz.BL.Services;
using OpenAI;
using OpenAI.Chat;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Notes2Quiz.BL.Impl.Services
{
    //TODO: this only generates one-correct-answer questions, show this in the name as well
    internal class QuizService : IQuizService
    {
        #region Fields
        private readonly ChatClient _chatClient;
        private readonly ChatCompletionOptions _options = new()
        {
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                    jsonSchemaFormatName: "quiz",
                    jsonSchema: BinaryData.FromBytes("""
                            {
                            "type": "object",
                            "properties": {
                            "questions": {
                                "type": "array",
                                "items": {
                                "type": "object",
                                "properties": {
                                    "question": { "type": "string" },
                                    "answer1": { "type": "string" },
                                    "answer2": { "type": "string" },
                                    "answer3": { "type": "string" },
                                    "answer4": { "type": "string" },
                                    "correct_answer": { "type": "string" }
                                },
                                "required": ["question", "answer1", "answer2", "answer3", "answer4", "correct_answer"],
                                "additionalProperties": false
                                }
                            }
                            },
                            "required": ["questions"],
                            "additionalProperties": false
                            }
                            """u8.ToArray()),
                        jsonSchemaIsStrict: true)
        };
        private readonly IQuizFactory _quizFactory;
        private readonly IQuestionFactory _questionFactory;
        #endregion

        #region ctor
        public QuizService(IApplicationSettings applicationSettings, IQuizFactory quizFactory, IQuestionFactory questionFactory)
        {
            if (applicationSettings is null)
            {
                throw new ArgumentNullException(nameof(applicationSettings));
            }

            var client = new OpenAIClient(applicationSettings.ApiKey);
            _chatClient = client.GetChatClient(Constants.Prompt.CHAT_CLIENT);
            _quizFactory = quizFactory ?? throw new ArgumentNullException(nameof(quizFactory));
            _questionFactory = questionFactory ?? throw new ArgumentNullException(nameof(questionFactory));
        }
        #endregion

        public async Task<string> DummyMethod(string input)
        {
            await Task.Run(() => { Thread.Sleep(1000); });
            var result = $"Hello, {input}!";
            return result;
        }

        public async Task<IQuiz> GenerateQuizFromText(string input, string quizName = "")
        {
            if (string.IsNullOrWhiteSpace(quizName))
            {
                quizName = "Studying Quiz";
            }

            //TODO: if quizName is null or whitespace, then generate a name for it
            var prompt = FormattableStringFactory.Create(Constants.Prompt.ONE_CORRECT_ANSWER_QUIZ_PROMPT, input);

            var completion = await _chatClient.CompleteChatAsync([new UserChatMessage(prompt.ToString())], _options);
            using JsonDocument structuredJson = JsonDocument.Parse(completion.Value.Content[0].Text);

            var questions = ExtractQuestionsFromResponse(structuredJson);
            var quiz = _quizFactory.CreateQuiz(quizName, questions);

            return quiz;
        }

        private IEnumerable<IQuestion> ExtractQuestionsFromResponse(JsonDocument structuredJson)
        {
            var questions = new List<IQuestion>();
            var questionArray = structuredJson.RootElement.GetProperty("questions");

            for (int i = 0; i < questionArray.GetArrayLength(); i++)
            {
                var element = questionArray[i];

                var question = element.GetProperty("question").GetString();
                var answer1 = element.GetProperty("answer1").GetString();
                var answer2 = element.GetProperty("answer2").GetString();
                var answer3 = element.GetProperty("answer3").GetString();
                var answer4 = element.GetProperty("answer4").GetString();
                var correctAnswer = element.GetProperty("correct_answer").GetString();

                questions.Add(_questionFactory.CreateOneCorrectAnswerQuestion(question, [answer1, answer2, answer3, answer4], correctAnswer));
            }

            return questions;
        }
    }
}
