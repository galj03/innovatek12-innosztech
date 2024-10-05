import { Card, Text } from "react-native-paper";

const Answer = (props: any) => {
  const answer = props.answer;

  return (
    <Card>
      <Card.Content>
        <Text variant="titleLarge">{ answer }</Text>
      </Card.Content>
    </Card>
  );
}

export default Answer;