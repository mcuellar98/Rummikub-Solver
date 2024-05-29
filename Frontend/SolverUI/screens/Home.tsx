import { Text, View } from "react-native";
import CustomButton from '../components/CustomButton';

export default function Index() {
  return (
    <View
      style={{
        flex: 1,
        justifyContent: "space-between",
        alignItems: "center",
        paddingTop: "80%",
        paddingBottom: "80%"
      }}
    >
      <CustomButton text="Manual Input"/>
      <CustomButton text="Take Photo of Board"/>
    </View>
  );
}
