import { View, Text, StyleSheet, Dimensions, Pressable } from 'react-native';
import { MutableRefObject, PropsWithChildren, useState } from 'react';

const screenWidth = Dimensions.get('window').width;
const screenHeight = Dimensions.get('window').height;

type Props = PropsWithChildren<{
  number: number,
  color: string,
  // selectedTiles: MutableRefObject<[number, string][]>;
}>;

export default function InputTypeButton({number, color}: Props) {

  const [borderColor, setBorderColor] = useState('grey');

  const handlePress = () => {
    setBorderColor('green');
    // selectedTiles.current.push([number, color])
  };

  return (
    <Pressable onPress={handlePress} style={styles.tile} >
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
    borderWidth: 0.5,
    // borderColor: '#adadad',
    borderRadius: 5
  },
  number: {
    fontSize: 14,
  },
});

