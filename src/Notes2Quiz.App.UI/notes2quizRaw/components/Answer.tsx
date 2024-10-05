import { Card, Text, Button } from "react-native-paper";
import { StyleSheet } from "react-native";
import { QuestionContext } from "@/hooks/QuestionContext";
import React, { useEffect } from "react";

const Answer = (props: any) => {
  const [givenAnswers, setGivenAnswers] = React.useContext(QuestionContext);
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

  return (
    <Button mode={givenAnswers[props.questionNumber] !== undefined && givenAnswers[props.questionNumber].value === answer ? "contained" : "outlined"} onPress={onCardPress}>
        <Text variant="titleLarge">{ answer }</Text>
    </Button>
  );
}

export default Answer;