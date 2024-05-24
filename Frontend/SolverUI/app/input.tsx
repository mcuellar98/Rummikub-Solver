import { Button, Text, View } from "react-native";
import TileRow from '../components/TileRow';
import CustomButton from "@/components/CustomButton";
import { useRef, useState } from "react";

export default function Input() {

  // const selectedTiles = useRef<[number, string[]>([]);
  const colors = ['blue', 'red', 'black', '#e67e00'];
  const tileGrid = colors.map((color) => <TileRow color={color} />);

  return (
    <View
      style={{
        flex: 1,
        alignItems: "center",
      }}>
        {tileGrid};

      <Button title="Submit"></Button>
    </View>
  );
}
