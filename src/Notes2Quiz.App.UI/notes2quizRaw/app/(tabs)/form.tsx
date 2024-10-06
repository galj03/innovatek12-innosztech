import { StyleSheet, View } from "react-native";
import { Button, Dialog, Text } from "react-native-paper";
import * as DocumentPicker from 'expo-document-picker';
import { QuizContext } from "@/hooks/QuizContext";
import FormData from 'form-data'
import React from "react";
import { Link } from "expo-router";
import { BaseUrl, Port } from "@/constants/RequestData";


export default function Index() {
    const [documentState, setDocumentState] = React.useState<{name: string, size: number | undefined, uri: string, type: string}>({
        name: "",
        size: 0,
        uri: "",
        type: "",
    });
    const [fileState, setFileState] = React.useState<Blob>();
    const [quizState, setQuizState] = React.useContext(QuizContext);
    const [dialogVisibility, setDialogVisibility] = React.useState(false);

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
                /*console.log("file----: " + file);*/
                setDocumentState(fileToUpload);
            }
            /*console.log(document);*/
        })
    };

    const postDocument = () => {
        const url = `${BaseUrl}:${Port}/api/quiz/pdf`;
        const fileUri = documentState.uri;
        const formdata = new FormData();
        //formdata.append('file', fileState!)
        formdata.append('file', {
            uri: fileUri,
           type: documentState.type, 
           name: documentState.name,
         });
        const options = {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'multipart/form-data',
            },
            body: formdata
        };
        /*console.log(fileUri);
        console.log(formdata);*/

        function reqListener() {
            const respJson = JSON.parse(req.responseText)
            setQuizState({...respJson, evaluated: false});
            setDialogVisibility(true);
        }
        function transferFailed() {
            console.log("File upload error:", req.responseText);
        }
          
          const req = new XMLHttpRequest();
          req.addEventListener("load", reqListener);
          req.addEventListener("error", transferFailed);
          req.open("POST", url);
          req.setRequestHeader("Accept", 'application/json');
          //req.setRequestHeader("Content-Type", 'multipart/form-data');
          req.send(formdata);
    }
    
    return (
        <View style={styles.container}>
            <Text style={styles.headlineText} variant="headlineMedium">Generate quiz by PDF!</Text>
            <Button onPress={openDocumentPicker}>Choose Document</Button>
            <Text style={styles.pickedText}>Selected: {documentState.name || "None"}</Text>
            <Button onPress={postDocument} mode="contained" disabled={documentState.name === ""}>Upload Document</Button>
            <Dialog visible={dialogVisibility} onDismiss={() => setDialogVisibility(false)}>
                <Dialog.Title>Quiz Ready!</Dialog.Title>
                <Dialog.Content>
                    <Text variant="bodyMedium">Your quiz is ready to take!</Text>
                </Dialog.Content>
                <Dialog.Actions>
                    <Link href={"/(tabs)/quiz"} onPress={() => setDialogVisibility(false)}>
                    <Text>Take your Quiz!</Text>
                    </Link>
                </Dialog.Actions>
            </Dialog>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex:1,
        justifyContent: "center",
        padding:30,
        gap:10,
    },
    pickedText: {
        textAlign: 'center',
    },
    headlineText: {
        textAlign: 'center',
        marginBottom: 20
    }
})