import { View, Text, StyleSheet, Dimensions, Pressable } from 'react-native';
import { MutableRefObject, PropsWithChildren, useRef, useState } from 'react';

type Props = PropsWithChildren<{
  number: number,
  color: string,
}>;

export default function ModalTile({number, color}: Props) {

  const [borderColor, setBorderColor] = useState('grey');
  const [boarderWidth, setBorderWidth] = useState(1);
  const tileIsSelected = useRef(false);

  return (
    <View  style={
      [styles.tile, { borderColor: borderColor}, { borderWidth: boarderWidth }]
    }>
      <Text style={[styles.number, {color: color}]}> {number}</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  tile: {
    // flex: 1,
    // flexDirection: 'row',
    justifyContent: 'center',
    alignItems:'center',
    height: 50,
    width: 30,
    // width: screenWidth/13,
    // height: screenHeight/14,
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

