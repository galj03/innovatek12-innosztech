namespace Notes2Quiz.BL.Impl
{
    public static class Constants
    {
        public static class Config
        {
            public const string CONFIG_PATH = "../../src/Notes2Quiz.BL.Impl/Config/ApplicationSettings.json";
        }

        public static class Prompt
        {
            public const string CHAT_CLIENT = "gpt-4o-mini";

            public static readonly string ONE_CORRECT_ANSWER_QUIZ_PROMPT = "Hello. I am a pupil, and I am preparing for one of my exams. Could you help me make a quiz so that I can test my knowledge? I will give you my notes and please generate 5 questions with 4 answers each."
                + Environment.NewLine + Environment.NewLine
                + "My notes:" + Environment.NewLine + "--------" + Environment.NewLine + "{0}" + Environment.NewLine + "--------" + Environment.NewLine + Environment.NewLine
                + "Please return the questions like this template:" + Environment.NewLine + Environment.NewLine
                + "Question: \"question text\"" + Environment.NewLine
                + "Answer1: \"answer 1\"" + Environment.NewLine
                + "Answer2: \"answer 2\"" + Environment.NewLine
                + "Answer3: \"answer 3\"" + Environment.NewLine
                + "Answer4: \"answer 4\"" + Environment.NewLine
                + "Correct answer: \"answer 1\"" + Environment.NewLine + Environment.NewLine
                + "Please, choose the correct answer out of the given ones.";
        }

        public static class User
        {
            public const string USER_NAME = "username";
        }
    }
}
