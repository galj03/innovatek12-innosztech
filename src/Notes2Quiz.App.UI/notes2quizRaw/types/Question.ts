import { QuestionTypeEnum } from "./QuestionTypeEnum"

export type Question = {
    questionText: string,
    questionType: QuestionTypeEnum,
    possibleAnswers: string[],
    correctAnswer: string
}