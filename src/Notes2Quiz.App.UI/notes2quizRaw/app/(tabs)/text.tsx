import React from "react";
import { View, StyleSheet } from "react-native";
import { Avatar, Button, Card, Text, TextInput } from "react-native-paper";

import { Quiz } from "../../types/Quiz"
import { QuestionTypeEnum } from "../../types/QuestionTypeEnum";

export default function Index() {
  const LeftContent = (props: any) => <Avatar.Icon {...props} icon="folder" />;
  const [text, setText] = React.useState("");
  const [responseText, setResponseText] = React.useState("");
  const [fetchTestText, setFetchTestText] = React.useState("");

  const sendText = () => {
    const requestBody: Quiz = {
      title: text,
      questions:[
        {
          questionText: text,
          questionType: QuestionTypeEnum.OneCorrectAnswerQuestion,
          possibleAnswers: ["answer 1", "answer2", "answer3", "answer4"],
          correctAnswer: "answer1"
        },
        {
          questionText: text,
          questionType: QuestionTypeEnum.OneCorrectAnswerQuestion,
          possibleAnswers: ["answer 1", "answer2", "answer3", "answer4"],
          correctAnswer: "answer1"
        },
        {
          questionText: text,
          questionType: QuestionTypeEnum.OneCorrectAnswerQuestion,
          possibleAnswers: ["answer 1", "answer2", "answer3", "answer4"],
          correctAnswer: "answer1"
        }
      ]
    };

    fetch("localhost:7029/api/quiz/text", {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(requestBody)
    }).then((response) => response.json())
    .then((json) => setFetchTestText(json))
    .catch((error) => console.log("fetch error: " + error));

    console.log(fetchTestText);

    //console.log("Sending text:");
    //console.log(text);
    setResponseText(text);
  }

  return (
    <View
      style={styles.container}
    >
      <TextInput
        label="Title"
        value={text}
        multiline={true}
        onChangeText={text => setText(text)}
      />

      <Button mode="contained" onPress={sendText}>
        Send text
      </Button>

      <Text>
        {responseText || "Awaiting message..."}
      </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    gap: 25,
    padding: 30,
  }
})