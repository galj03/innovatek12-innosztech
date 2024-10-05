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

    await fetch("https://192.168.27.241:7029/api/Quiz/dummy", {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({text: "valami"})
    }).then((response) => response.json())
    .then((json) => console.log(json))
    .catch((error) => console.log("fetch error: " + error));

    let generatedText: string | null = "";
    console.log(fetchTestText);

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
    setResponseText(fetchTestText || "Generating text...");
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