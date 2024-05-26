import { Button, Text, View } from "react-native";
import TileRow from '../components/TileRow';
import CustomButton from "@/components/CustomButton";
import { useRef, useState } from "react";

export default function Input() {

  // const selectedTiles = useRef<[number, string[]>([]);
  const colors = ['blue', 'blue', 'red','red', 'black','black', '#e67e00', '#e67e00'];

  return (
    <View
      style={{
        flex: 1,
        alignItems: "center",
      }}>
      {colors.map((color) => <TileRow color={color}/>)}
      <Button title="Submit"></Button>
    </View>
  );
}
