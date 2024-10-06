import { StyleSheet, View } from "react-native";
import { QuestionComponent} from "../../components/Question";
import React from "react";
import { DataTable, Button, Text, Dialog } from "react-native-paper";
import { Question } from "@/types/Question";
import { QuestionProvider } from "@/hooks/QuestionContext";
import { QuizContext } from "@/hooks/QuizContext";
import { Link } from "expo-router";


export default function Index() {
  const [quizState, setQuizState] = React.useContext(QuizContext);

  const [answerEval, setAnswerEval] = React.useState(false);
  const [page, setPage] = React.useState<number>(!quizState || !quizState.questions ? 0 : quizState.questions.length);
  const [numberOfItemsPerPageList] = React.useState([1]);
  const [itemsPerPage, onItemsPerPageChange] = React.useState(
    numberOfItemsPerPageList[0]
  );

  const [items, setItems] = React.useState(!quizState  ? [] : quizState.questions);

  
  const from = page * itemsPerPage;
  const to = Math.min((page + 1) * itemsPerPage, items.length);
  
  React.useEffect(() => {
    setPage(0);
  }, [itemsPerPage]);

  React.useEffect(() => {
    setItems(quizState ? quizState.questions : []);
  }, [quizState])
  
  if (quizState === undefined) {
    return (
      <View style={styles.container}>
        <Link href={"/(tabs)/text"}> 
          <Text>No quizzes loaded! Go back and load it!</Text>
        </Link>
      </View>
    )
  }

  const evaluate = () => {
    const nextQuizState = {
      ...quizState,
      evaluated: true,
      correctAnswerNumber: 0
    };

    setQuizState(nextQuizState);
    setAnswerEval(true);
  }

  const showResults = () => {
    setPage(0);
    setAnswerEval(false);
  }

  return (
    <View style={styles.container}>
      <DataTable style={styles.questionContainer}>
        <QuestionProvider>
          {
            items.slice(from, to).map((question: Question, index: number) => (

              <QuestionComponent questionNumber={from} visitedQuestions={[]} key={index} propQuestion={question} />
            ))
          }
        </QuestionProvider>
      </DataTable>

      <Text>{`${from + 1} of ${items.length}`}</Text>
      <DataTable.Pagination
        page={page}
        numberOfPages={Math.ceil(items.length / itemsPerPage)}
        onPageChange={(page) => setPage(page)}
        numberOfItemsPerPageList={numberOfItemsPerPageList}
        numberOfItemsPerPage={itemsPerPage}
        showFastPaginationControls
        style={styles.paginationButtons}
        
      />
      <Button onPress={evaluate} style={styles.submitButton} mode="contained" disabled={from + 1 !== quizState.questions.length || quizState.evaluated}>
        <Text style={styles.submitText}>Submit</Text>
      </Button>
      <Dialog visible={answerEval} onDismiss={() => setAnswerEval(false)}>
        <Dialog.Title>Evaluation Ready!</Dialog.Title>
          <Dialog.Content>
            <Text variant="bodyMedium">Quiz evaluated! Let's see how you did!</Text>
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={showResults}>
              <Text>Show Answers!</Text>
            </Button>
          </Dialog.Actions>
      </Dialog>
    </View>
  );

    /*return (
      <View style={styles.container}>
          <QuizComponent title={quiz.title} questions={quiz.questions} />
      </View>
    );*/
}

const styles = StyleSheet.create({
  container: {
    padding: 30,
    flex: 1,
    justifyContent: "flex-end",
    alignItems: "center",
    
  },
  questionContainer: {
    marginBottom: 50
  },
  paginationButtons: {
    textAlign: "center",
    paddingRight: 16,
    marginHorizontal: "auto",
    flexDirection:"column"
  },
  submitButton: {
    width:200,
  },
  submitText: {
    fontSize: 20,
  }
})