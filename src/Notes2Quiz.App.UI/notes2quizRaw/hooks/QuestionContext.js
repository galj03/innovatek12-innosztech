import React from "react";

export const QuestionContext = React.createContext();

export const QuestionProvider = (props) => {
    const [givenAnswers, setGivenAnswers] = React.useState([]);

    return (
        <QuestionContext.Provider value={[givenAnswers, setGivenAnswers]}>
            {props.children}
        </QuestionContext.Provider>
    );
}