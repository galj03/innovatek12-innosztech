import { StyleSheet, View } from "react-native";
import { Button, Text } from "react-native-paper";
import * as DocumentPicker from 'expo-document-picker';
import * as FileSystem from 'expo-file-system';
import React from "react";


export default function Index() {
    const [documentState, setDocumentState] = React.useState<{name: string | undefined, size: number | undefined, uri: string | undefined, type: string}>({
        name: "",
        size: -1,
        uri: "",
        type: "",
    });

    const openDocumentPicker = async () => {
        const document = await DocumentPicker.getDocumentAsync({
            type: 'application/pdf',
            copyToCacheDirectory: true,
        }).then((document: DocumentPicker.DocumentPickerResult) => {
            if (!document.canceled) {
                let name = document.assets.at(0);
                let size = document.assets.at(0);
                let uri = document.assets.at(0);

                var fileToUpload = {
                    name: name?.name,
                    size: size?.size,
                    uri: uri?.uri,
                    type: "application/pdf"
                };
                console.log(fileToUpload);
                setDocumentState(fileToUpload);
            }
            console.log(document);
        })
    };

    const postDocument = () => {
        const url = "http://192.168.27.14:8080/api/quiz/pdf";
        const fileUri = documentState.uri;
        const options = {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'multipart/form-data',
            },
        };
        console.log(fileUri);
        FileSystem.uploadAsync(url, fileUri!, options)
        .then((response) => {
            console.log(response);
        })
        .catch((error) => {
            console.log("upload error: " + error)
        });
    }
    
    return (
        <View style={styles.container}>
            <Text>{documentState.name}</Text>
            <Button onPress={openDocumentPicker}>Choose Document</Button>
            <Button onPress={postDocument} mode="contained" disabled={documentState.name === ""}>Upload Document</Button>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex:1,
        justifyContent: "center"
    }
})