import React from "react";

export const QuizContext = React.createContext();

export const QuizProvider = (props) => {
    const [givenAnswers, setGivenAnswers] = React.useState([]);
    const [selectedQuestion, setSelectedQuestion] = React.useState("");

    return (
        <QuizContext.Provider value={[givenAnswers, setGivenAnswers]}>
            {props.children}
        </QuizContext.Provider>
    );
}