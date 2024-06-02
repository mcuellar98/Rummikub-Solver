import { View, Text, StyleSheet, Dimensions, Pressable } from 'react-native';
import { MutableRefObject, PropsWithChildren, useRef, useState } from 'react';

const screenWidth = Dimensions.get('window').width;
const screenHeight = Dimensions.get('window').height;

type Props = PropsWithChildren<{
  number: number,
  color: string,
  selectedTiles: MutableRefObject<{number: number, color: string}[]>;
}>;

export default function Tile({number, color, selectedTiles}: Props) {

  const [borderColor, setBorderColor] = useState('grey');
  const [boarderWidth, setBorderWidth] = useState(1);
  const tileIsSelected = useRef(false);

  const handlePress = () => {
    if (!tileIsSelected.current) {
      tileIsSelected.current = true;
      setBorderColor('green');
      setBorderWidth(3);
      selectedTiles.current.push({color:color, number: number})
    } else {
      tileIsSelected.current = false;
      setBorderColor('grey');
      setBorderWidth(1);
      removeTile()
    }
  };

  const removeTile = () => {
    for (var i = 0; i < selectedTiles.current.length; i++) {
      var tile = selectedTiles.current[i];
      if (tile.number === number && tile.color === color) {
        selectedTiles.current = selectedTiles.current.filter((tile, index) => index !==i);
        break;
      }
    }
  }

  return (
    <Pressable onPress={handlePress} style={[styles.tile, { borderColor: borderColor}, { borderWidth: boarderWidth }] }>
      <Text style={[styles.number, {color: color}]}> {number}</Text>
    </Pressable>
  );
}

const styles = StyleSheet.create({
  tile: {
    flex: 1,
    justifyContent: 'center',
    alignItems:'center',
    width: screenWidth/13,
    height: screenHeight/14,
    backgroundColor: 'white',
    borderStyle: 'solid',
    // borderWidth: 0.5,
    // borderColor: '#adadad',
    borderRadius: 5
  },
  number: {
    fontSize: 14,
  },
});

