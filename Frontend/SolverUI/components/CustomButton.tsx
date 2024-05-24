import { TouchableOpacity, Text, StyleSheet } from 'react-native';
import type { PropsWithChildren, ReactElement } from 'react';
import { useRouter } from "expo-router";

type Props = PropsWithChildren<{
  text: string
}>;

export default function CustomButton({text}: Props) {
  const router = useRouter();
  return (
    <TouchableOpacity style={styles.button} onPress={() => {router.navigate('input')}}>
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

