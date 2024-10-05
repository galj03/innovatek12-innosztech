import { Avatar, Button, Card, Text, DataTable } from 'react-native-paper';
import { StyleSheet, View } from 'react-native';
import QuestionComponent from './Question';
import React from 'react';
import { Question } from '@/types/Question';

const Quiz = (props: any) => {
  const [page, setPage] = React.useState<number>(props.questions.length);
  const [numberOfItemsPerPageList] = React.useState([2, 3, 4]);
  const [itemsPerPage, onItemsPerPageChange] = React.useState(
    numberOfItemsPerPageList[0]
  );

  const [items] = React.useState(props.questions);

  const from = page * itemsPerPage;
  const to = Math.min((page + 1) * itemsPerPage, items.length);

  React.useEffect(() => {
    setPage(0);
  }, [itemsPerPage]);

  return (
    <DataTable>
      {
        items.slice(from, to).map((item: Question, i: number) => {
          <DataTable.Row key={i}>
            <DataTable.Cell>{item.}</DataTable.Cell>
          </DataTable.Row>
        })
      }
    </DataTable>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    gap:10
  }
})

export default Quiz;