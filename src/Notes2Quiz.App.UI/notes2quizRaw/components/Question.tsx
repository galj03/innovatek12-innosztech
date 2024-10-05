import { Question } from '@/types/Question';
import { Avatar, Button, Card, DataTable, Text } from 'react-native-paper';
import { View, StyleSheet } from 'react-native';
import Answer from './Answer';


export const QuestionComponent = (props: any) => {
  const propQuestion: Question = props.propQuestion;

  return (
      <View style={styles.container}>
        <Text style={styles.headerText} variant='headlineLarge'>{propQuestion.questionText}</Text>
        <View style={styles.answerContainer}>
          {
            propQuestion.possibleAnswers.map((answer: string, index: number) => {
                return ( 
                  <Answer key={index} answer={answer} />
                );
              }
            )
          }
          </View>
      </View>
    );
}

const styles = StyleSheet.create({
  container: {
    gap:40,
    justifyContent: "flex-end"
  },
  headerText: {
    fontSize: 40,
    textAlign: "center",
  },
  answerContainer: {
    gap: 15,
  }
});
