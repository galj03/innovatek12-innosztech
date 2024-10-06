import { StyleSheet, View } from "react-native";
import { Button, Text } from "react-native-paper";
import * as DocumentPicker from 'expo-document-picker';
import * as FileSystem from 'expo-file-system';
import React from "react";


export default function Index() {
    const [documentState, setDocumentState] = React.useState<{name: string, size: number | undefined, uri: string, type: string}>({
        name: "",
        size: 0,
        uri: "",
        type: "",
    });
    const [fileState, setFileState] = React.useState<Blob>();

    const openDocumentPicker = async () => {
        const document = await DocumentPicker.getDocumentAsync({
            type: 'application/pdf',
            copyToCacheDirectory: true,
        }).then((document: DocumentPicker.DocumentPickerResult) => {
            if (!document.canceled) {
                let file = document.assets.at(0)?.file;
                let name = document.assets.at(0)!.name;
                let size = document.assets.at(0)!.size;
                let uri = document.assets.at(0)!.uri;

                var fileToUpload = {
                    name: name,
                    size: size,
                    uri: uri,
                    type: "application/pdf"
                };

                fetch(uri).then((response) => {
                    response.blob().then((blob) => {
                        setFileState(blob);
                    }).catch((error) => console.log("Blob error: " + error))
                }).catch((error) => console.log("Fetch error: " + error))
                console.log("file----: " + file);
                setDocumentState(fileToUpload);
            }
            console.log(document);
        })
    };

    const postDocument = () => {
        const url = "http://192.168.27.14:8080/api/quiz/pdf";
        const fileUri = documentState.uri;
        const formdata = new FormData();
        formdata.append('file', fileState!)
        const options = {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'multipart/form-data',
            },
            body: formdata
        };
        console.log(fileUri);
        console.log(formdata);
        fetch(url, options).then((response) => console.log(response)).catch((error) => console.log("pdf upload error: " + error))
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