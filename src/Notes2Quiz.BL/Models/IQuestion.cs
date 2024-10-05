﻿using Notes2Quiz.BL.Enums;

namespace Notes2Quiz.BL.Models
{
    public interface IQuestion
    {
        string QuestionText { get; }
        QuestionType QuestionType { get; }
        IEnumerable<string> PossibleAnswers { get; }
        IEnumerable<string> CorrectAnswers { get; }
    }
}
