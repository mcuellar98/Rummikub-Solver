import { Button, Text, View } from "react-native";
import TileRow from '../components/TileRow';
import { useRef, useState } from "react";
import axios from 'axios';

const colors = ['blue', 'blue', 'red','red', 'black','black', '#e67e00', '#e67e00'];

export default function Input() {

  const selectedTiles = useRef([]);

  const handlePress = () => {
    axios.post('http://localhost:5044/test',selectedTiles.current)
    .then((response) => {
      // console.log(response.data)
      // response.data.forEach((board) => {
      //   console.log(board);
      // })
    })
    .catch((err) => console.log(err))
  };

  return (
    <View
      style={{
        flex: 1,
        alignItems: "center",
      }}>
      {colors.map((color,index) => <TileRow color={color} selectedTiles={selectedTiles} row={index}/>)}
      <Button title="Submit" onPress={handlePress}></Button>
    </View>
  );
}
