import React from "react";
import { View, StyleSheet } from "react-native";
import { Avatar, Button, Card, Text, TextInput } from "react-native-paper";
import { openai } from "../../config/OpenAi";

import { Quiz } from "../../types/Quiz"
import { QuestionTypeEnum } from "../../types/QuestionTypeEnum";

export default function Index() {
  const LeftContent = (props: any) => <Avatar.Icon {...props} icon="folder" />;
  const [text, setText] = React.useState("");
  const [responseText, setResponseText] = React.useState("");
  const [fetchTestText, setFetchTestText] = React.useState("");

  const sendText = async () => {
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

    let bodyMessage = JSON.stringify({text:"valami"})

    console.log("Fetching...");
    await fetch("http://192.168.27.14:8080/api/quiz/dummy", {
      method: 'POST',
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({text: text})
    }).then(async (response) => await response.json())
    .then((json) => setResponseText(json.text))
    .catch((error) => console.log("fetch error: " + error));

    /*const response = await openai.chat.completions.create({
      model: 'gpt-4o-mini',
      messages: [
        {"role": "system", "content": text}
      ]
    }).then((responseFromOpenAi) => {
      responseFromOpenAi.choices.forEach((item) => {
        console.log(item.message);
        generatedText = item.message.content;
      });
    });*/

    //console.log("Sending text:");
    //console.log(text);
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