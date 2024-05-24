import { View, Text, StyleSheet, Dimensions } from 'react-native';
import type { MutableRefObject, PropsWithChildren, ReactElement } from 'react';
import Tile from './Tile';

const screenWidth = Dimensions.get('window').width;
const screenHeight = Dimensions.get('window').height;

type Props = PropsWithChildren<{
  color: string,
  // selectedTiles: MutableRefObject<[number, string][]>;
}>;

export default function InputTypeButton({color}: Props) {

  const tileRow = [];
  for (var i = 1; i < 14; i++) {
    tileRow.push(<Tile number={i} color={color} key={i} />);
  }
  return (
    <View style={styles.rowContainer}>
      {tileRow}
    </View>
  );
}

const styles = StyleSheet.create({
  rowContainer: {
    paddingLeft: 5,
    paddingBottom: 2,
    paddingTop: 2,
    paddingRight: 5,
    flexDirection: 'row',
  }
});

