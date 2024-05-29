import { Button, Text, View } from "react-native";
import TileRow from '../components/TileRow';
import CustomButton from "@/components/CustomButton";
import { useRef, useState } from "react";

const colors = ['blue', 'blue', 'red','red', 'black','black', '#e67e00', '#e67e00'];

export default function Input() {

  const selectedTiles = useRef([]);

  const handlePress = () => {
    console.log(selectedTiles.current);
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
