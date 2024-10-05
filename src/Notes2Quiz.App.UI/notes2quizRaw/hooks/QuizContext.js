import React from "react";

export const QuizContext = React.createContext();

export const QuizProvider = (props) => {
    const [quizState, setQuizState] = React.useState();
    
    return (
        <QuizContext.Provider value={[quizState, setQuizState]}>
            {props.children}
        </QuizContext.Provider>
    );
}