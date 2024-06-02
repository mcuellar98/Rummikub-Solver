import React, {Dispatch, MutableRefObject, PropsWithChildren, SetStateAction, useState} from 'react';
import {Alert, Modal, StyleSheet, Text, Pressable, View, ScrollView} from 'react-native';
import ModalTile from '../components/ModalTile';
import ModalTileSet from '../components/ModalTileSet';

type RootStackParamList = {
  ManualInput: undefined;
};

type Props = PropsWithChildren<{
  modalVisisble: boolean,
  setModalVisible: Dispatch<SetStateAction<boolean>>,
  validBoards: MutableRefObject<any[]>
}>;

const ValidBoardsModal = ({ modalVisible, setModalVisible, validBoards}) => {
  return (
    <View style={styles.centeredView}>
      <Modal
        animationType="slide"
        transparent={true}
        visible={modalVisible}
        onRequestClose={() => {
          Alert.alert('Modal has been closed.');
          setModalVisible(!modalVisible);
        }}>
        <View style={styles.centeredView}>
          <View style={styles.modalView}>
            {/* <Text style={styles.modalText}>{validBoards.length === 1 ? `There is 1 solution` : `There are ${validBoards.length} solutions`}</Text> */}
            {validBoards.length > 0 ? validBoards[0].map((sets: { tiles: { number: number; color: string; }[]}) => <ModalTileSet tiles={sets.tiles}/>) : <Text>There are no solutions</Text>}
            <Pressable
              style={[styles.button, styles.buttonClose]}
              onPress={() => setModalVisible(!modalVisible)}>
              <Text style={styles.textStyle}>Hide Modal</Text>
            </Pressable>
          </View>
        </View>
      </Modal>
    </View>
  );
};

const styles = StyleSheet.create({
  centeredView: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    // marginTop: 22,
  },
  modalView: {
    margin: 20,
    backgroundColor: 'white',
    borderRadius: 20,
    padding: 35,
    maxHeight: '75%',
    maxWidth: '80%',
    alignItems: 'center',
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 4,
    elevation: 5,
  },
  button: {
    borderRadius: 20,
    padding: 10,
    elevation: 2,
  },
  buttonOpen: {
    backgroundColor: '#F194FF',
  },
  buttonClose: {
    marginTop: 20,
    backgroundColor: '#2196F3',
  },
  textStyle: {
    color: 'white',
    fontWeight: 'bold',
    textAlign: 'center',
  },
  modalText: {
    marginBottom: 15,
    textAlign: 'center',
  },
  setsContainer: {
    // flex:
    // flexDirection: 'row',
    margin: 20,
  },
  rowContainer: {
    flexDirection:'row',
    borderWidth: 1,
    borderColor:'red'
  }
});

export default ValidBoardsModal;