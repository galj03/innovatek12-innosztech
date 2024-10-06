import React, { useEffect } from "react";
import { View, StyleSheet } from "react-native";
import { Avatar, Button, Card, Dialog, Text, TextInput } from "react-native-paper";
import { Quiz } from "../../types/Quiz"
import { Link } from "expo-router";
import { QuizContext } from "@/hooks/QuizContext";
import { Question } from "@/types/Question";
import { BaseUrl, Port } from "@/constants/RequestData";

export default function Index(props: any) {
  const LeftContent = (props: any) => <Avatar.Icon {...props} icon="folder" />;
  const [text, setText] = React.useState("");
  const [responseText, setResponseText] = React.useState("");
  const [fetchQuiz, setFetchQuiz] = React.useState<Quiz>();
  const [dialogVisibility, setDialogVisibility] = React.useState(false);
  const [quizState, setQuizState] = React.useContext(QuizContext);

  const sendText = async () => {
    setQuizState(undefined);
    text.replace("/(\r\n|\n|\r)/gm", "");

    console.log("Fetching...");
    await fetch(`${BaseUrl}:${Port}/api/quiz/text`, {
      method: 'POST',
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({text: text})
    }).then((response) => response.json())
    .then((json) => {
      setQuizState({...json, evaluated: false, correctAnswersNumber: 0});
      setDialogVisibility(true);
    })
    .catch((error) => console.log("fetch error: " + error));
  }

  useEffect(() => {
    if (quizState !== undefined) {
      console.log("-----------------")
      console.log(quizState.title)
      quizState.questions.forEach((item: Question) => {
        console.log(item.questionText)
        console.log(item.possibleAnswers)
        console.log(item.correctAnswers)
      })
      console.log("-----------------")
    }
  }, [quizState])

  return (
    <View
      style={styles.container}
    >
      <TextInput
        label="Title"
        value={text}
        multiline={true}
        onChangeText={text => setText(text)}
        style={styles.inputField}
      />

      <Button mode="contained" onPress={sendText}>
        Send text
      </Button>

      <Text>
        {responseText || "Awaiting message..."}
      </Text>

      <Dialog visible={dialogVisibility} onDismiss={() => setDialogVisibility(false)}>
        <Dialog.Title>Quiz Ready!</Dialog.Title>
          <Dialog.Content>
            <Text variant="bodyMedium">Your quiz is ready to take!</Text>
          </Dialog.Content>
          <Dialog.Actions>
            <Link href={"/(tabs)/quiz"} onPress={() => setDialogVisibility(false)}>
              <Text>Take your Quiz!</Text>
            </Link>
          </Dialog.Actions>
      </Dialog>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    gap: 25,
    padding: 30,
  },
  inputField: {
    maxHeight: 300,
  }
})