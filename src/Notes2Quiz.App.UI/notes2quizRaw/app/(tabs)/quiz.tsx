import { StyleSheet, View } from "react-native";
import { QuestionComponent} from "../../components/Question";
import React from "react";
import { DataTable, Button, Text } from "react-native-paper";
import { Question } from "@/types/Question";
import { QuestionProvider } from "@/hooks/QuestionContext";
import { QuizContext } from "@/hooks/QuizContext";
import { Link } from "expo-router";


export default function Index() {
  const [quizState, setQuizState] = React.useContext(QuizContext);

  if (quizState === undefined) {
    return (
      <View style={styles.container}>
        <Link href={"/(tabs)/text"}> 
          <Text>No quizzes loaded! Go back and load it!</Text>
        </Link>
      </View>
    )
  }

  const [page, setPage] = React.useState<number>(quizState.questions.length);
  const [numberOfItemsPerPageList] = React.useState([1]);
  const [itemsPerPage, onItemsPerPageChange] = React.useState(
    numberOfItemsPerPageList[0]
  );

  const [items] = React.useState(quizState.questions);

  const from = page * itemsPerPage;
  const to = Math.min((page + 1) * itemsPerPage, items.length);

  React.useEffect(() => {
    setPage(0);
  }, [itemsPerPage]);

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
      <Button style={styles.submitButton} mode="contained" disabled={from + 1 !== quizState.questions.length}>
        <Text style={styles.submitText}>Submit</Text>
      </Button>
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