import { Card, Text, Button } from "react-native-paper";
import { StyleSheet } from "react-native";
import { QuestionContext } from "@/hooks/QuestionContext";
import React, { useEffect } from "react";
import { QuizContext } from "@/hooks/QuizContext";

const Answer = (props: any) => {
  const [givenAnswers, setGivenAnswers] = React.useContext(QuestionContext);
  const [quizState, setQuizState] = React.useContext(QuizContext);
  const answer: string = props.answer;

  const onCardPress = () => {
    let found = false;
    let nextGivenAnswers = givenAnswers.map((item: {id: number, value: string}) => {
      if (props.questionNumber === item.id) {
        found = true;
        return {
          id: item.id,
          value: answer
        };
      } else {
        return item;
      }
    })

    if (found === false) {
      nextGivenAnswers = [...nextGivenAnswers, {id: props.questionNumber, value: answer}]
    }

    console.log(givenAnswers);
    setGivenAnswers(nextGivenAnswers);
    //console.log(props.questionNumber)
  }

  if (quizState.evaluated) {
    const correctAnswer = quizState.questions[props.questionNumber].correctAnswers[0]
    const style = correctAnswer === answer ? styles.correctAnswer : givenAnswers[props.questionNumber] && givenAnswers[props.questionNumber].value === answer ? styles.choosenWrongAnswer : styles.wrongAnswer

    return (
      <Button
        disabled={quizState.evaluated} 
        mode={givenAnswers[props.questionNumber] !== undefined && givenAnswers[props.questionNumber].value === answer ? "contained" : "outlined"}
        onPress={onCardPress}
        style={style}  
      >
          <Text variant="bodyLarge">{ answer }</Text>
      </Button>
    );
  }

  return (
    <Button
      disabled={quizState.evaluated} 
      mode={givenAnswers[props.questionNumber] !== undefined && givenAnswers[props.questionNumber].value === answer ? "contained" : "outlined"}
      onPress={onCardPress}  
    >
        <Text variant="bodyLarge">{ answer }</Text>
    </Button>
  );

}

export default Answer;

const styles = StyleSheet.create({
  correctAnswer: {
    backgroundColor: "green"
  },
  wrongAnswer: {

  },
  choosenWrongAnswer: {
    backgroundColor: "red"
  }
});