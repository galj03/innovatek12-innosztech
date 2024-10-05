import { QuestionTypeEnum } from "@/types/QuestionTypeEnum";
import { Quiz } from "@/types/Quiz";

export const quiz: Quiz = {
    title: "First quiz",
    questions:[
      {
        questionText: "How are you?",
        questionType: QuestionTypeEnum.OneCorrectAnswerQuestion,
        possibleAnswers: ["amizing", "Not that good", "Wrong Answer", "Gercsó"],
        correctAnswers: ["amizing"]
      },
      {
        questionText: "What day it is today?",
        questionType: QuestionTypeEnum.OneCorrectAnswerQuestion,
        possibleAnswers: ["Monday", "Fryday", "Saturday", "Sunday"],
        correctAnswers: ["Saturday"]
      },
      {
        questionText: "What is the weather like now?",
        questionType: QuestionTypeEnum.OneCorrectAnswerQuestion,
        possibleAnswers: ["Rainy", "Sunny", "Very hot", "Very big"],
        correctAnswers: ["Rainy"]
      }
    ]
  };