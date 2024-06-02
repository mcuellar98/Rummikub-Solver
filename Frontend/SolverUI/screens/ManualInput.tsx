import { Button, Text, View } from "react-native";
import TileRow from '../components/TileRow';
import { useRef, useState } from "react";
import axios from 'axios';
import ValidBoardsModal from "../modals/ValidBoardsModal";

const colors = ['blue', 'blue', 'red','red', 'black','black', '#e67e00', '#e67e00'];

export default function Input() {

  const [modalVisible, setModalVisible] = useState(false);
  const [validBoards, setValidBoards] = useState([]);

  // const validBoards = useRef([]);
  const selectedTiles = useRef([]);

  const handlePress = () => {
    axios.post('http://localhost:5044/test',selectedTiles.current)
    .then((response) => {
      setModalVisible(true);
      setValidBoards(response.data);
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
      <ValidBoardsModal modalVisible={modalVisible} setModalVisible={setModalVisible} validBoards={validBoards}/>
    </View>
  );
}
