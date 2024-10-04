import { Pressable, StyleSheet, TouchableOpacity, View } from "react-native";
import { QuestionComponent} from "../../components/Question";
import { quiz } from "../../constants/QuizList";
import React from "react";
import { DataTable, Button, Text } from "react-native-paper";
import { Question } from "@/types/Question";


export default function Index() {
  
  const [page, setPage] = React.useState<number>(quiz.questions.length);
  const [numberOfItemsPerPageList] = React.useState([1]);
  const [itemsPerPage, onItemsPerPageChange] = React.useState(
    numberOfItemsPerPageList[0]
  );

  const [items] = React.useState(quiz.questions);

  const from = page * itemsPerPage;
  const to = Math.min((page + 1) * itemsPerPage, items.length);

  React.useEffect(() => {
    setPage(0);
  }, [itemsPerPage]);

  return (
    <View style={styles.container}>
      <DataTable style={styles.questionContainer}>
        {
          items.slice(from, to).map((question: Question, index: number) => (

            <QuestionComponent key={index} propQuestion={question} />
          ))
        }
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
      <Button mode="contained" disabled={from + 1 !== quiz.questions.length}>Submit</Button>
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
    
  }
})