import { View, Text, StyleSheet, Dimensions } from 'react-native';
import type { MutableRefObject, PropsWithChildren, ReactElement } from 'react';
import ModalTile from './ModalTile';


type Props = PropsWithChildren<{
  // color: string,
  tiles: {number: number, color: string}[],
  // row: number;
}>;


export default function ModalTileSet({tiles}: Props) {

  const tileRow = [];
  for (var tile of tiles) {
    tileRow.push(<ModalTile number={tile.number} color={tile.color}/>);
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

