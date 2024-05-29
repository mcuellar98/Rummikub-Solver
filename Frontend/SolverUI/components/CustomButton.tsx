import { TouchableOpacity, Text, StyleSheet } from 'react-native';
import type { PropsWithChildren, ReactElement } from 'react';
import { useNavigation } from '@react-navigation/native';
import { NativeStackNavigationProp } from '@react-navigation/native-stack';


type RootStackParamList = {
  ManualInput: undefined;
};

type Props = PropsWithChildren<{
  text: string,
}>;

export default function CustomButton({text}: Props) {

  const navigation = useNavigation<NativeStackNavigationProp<RootStackParamList>>();

  return (
    <TouchableOpacity style={styles.button} onPress={() => {navigation.push('ManualInput')}}>
      <Text style={styles.buttonText}>{text}</Text>
    </TouchableOpacity>
  );
}

const styles = StyleSheet.create({
  button: {
    width: 200,
    height: 50,
    backgroundColor: '#007BFF',
    justifyContent: 'center',
    alignItems: 'center',
    borderRadius: 5,
  },
  buttonText: {
    color: '#FFFFFF',
    fontSize: 16,
  },
});

