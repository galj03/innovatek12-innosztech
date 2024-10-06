import { Camera, CameraCapturedPicture, CameraType, CameraView, FlashMode, useCameraPermissions } from "expo-camera";
import { useState, useRef, useContext } from "react";
import {  Pressable, StyleSheet, TouchableOpacity, View } from "react-native";
import { Button, Dialog, Text} from "react-native-paper";
import { BaseUrl, Port } from "@/constants/RequestData";
import * as ImagePicker from 'expo-image-picker';
import FormData from 'form-data'
import { QuizContext } from "@/hooks/QuizContext";
import { Link } from "expo-router";
import { SkipEnteringContext } from "react-native-reanimated/lib/typescript/reanimated2/component/LayoutAnimationConfig";

export default function Index() {
  const [facing, setFacing] = useState<CameraType>('back');
  const [permission, requestPermission] = useCameraPermissions();
  const [quizState, setQuizState] = useContext(QuizContext);
  const [dialogVisibility, setDialogVisibility] = useState(false);
  const cameraRef = useRef<CameraView>(null);

  if (!permission) {
    // Camera permissions are still loading.
    return <View />;
  }

  if (!permission.granted) {
    // Camera permissions are not granted yet.
    return (
      <View style={styles.container}>
        <Button mode="outlined" onPress={requestPermission}>
          <Text>Please enable camera to scan your notes!</Text>
        </Button>
      </View>
    );
  }

  const takePicture = async () => {
    setQuizState(undefined);
    if (cameraRef.current) {
      let photo = await cameraRef.current.takePictureAsync({
        quality: 0,
      }).then((photo: CameraCapturedPicture | undefined) => {
        let url = `${BaseUrl}:${Port}/api/quiz/images`;
        let fileUri = photo?.uri;
        let splittedUri = photo?.uri.split("/");
        let name = splittedUri![splittedUri!.length - 1].split(".")[0];
        let type = "image/" + splittedUri![splittedUri!.length - 1].split(".")[1];
        
        const formdata = new FormData();
        formdata.append("images", {
          name: name,
          uri: fileUri,
          type: "image/jpeg",
        });

        /*console.log([{
          name: name,
          uri: fileUri,
          type: type
        }]);*/

        function reqListener() {
          /*console.log(req.responseText);*/

          setQuizState({...JSON.parse(req.responseText), evaluated: false, correctAnswersNumber: 0});
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

        /*console.log(photo)*/
      }).catch((error: any) => {
        console.log("picture take error: " + error);
      })
      
    }
  };

  const toggleCameraFacing = () => {
    setFacing(current => (current === 'back' ? 'front' : 'back'));
  }

  const pickImages = async () => {
    setQuizState(undefined);
    let result = await ImagePicker.launchImageLibraryAsync({
      quality: 1,
    });

    if (!result.canceled) {
      /*console.log(result);*/
    } else {
      alert('You did not select any image.');
    }

    let url = `${BaseUrl}:${Port}/api/quiz/images`;
    const formdata = new FormData();
    /*formdata.append("images", result.assets?.map((item) => {
      return {
        name: item.fileName,
        uri: item.uri,
        type: item.mimeType
      }
    }));*/
    formdata.append("images", {
      name: result.assets!.at(0)!.fileName,
      uri: result.assets!.at(0)?.uri,
      type: result.assets!.at(0)!.mimeType
    })

    /*console.log(result.assets?.map((item) => {
      return {
        name: item.fileName,
        uri: item.uri,
        type: item.mimeType
      }
    }));*/

    function reqListener() {
      /*console.log(req.responseText);*/

      setQuizState({...JSON.parse(req.responseText), evaluated: false, correctAnswersNumber: 0});
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
        <CameraView style={styles.camera} facing={facing} ref={cameraRef}>
        <View style={styles.buttonContainer}>
          <TouchableOpacity style={styles.button} onPress={toggleCameraFacing}>
            <Text variant="bodyLarge" style={styles.text}>Flip Camera</Text>
          </TouchableOpacity>
          <TouchableOpacity style={styles.button} onPress={takePicture}>
            <Text variant="headlineSmall" style={styles.text}>Take picture</Text>
          </TouchableOpacity>
          <TouchableOpacity style={styles.button} onPress={pickImages}>
            <Text variant="bodyLarge" style={styles.text}>Upload</Text>
          </TouchableOpacity>
        </View>
      </CameraView>
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
    flex: 1,
    justifyContent: 'center',
  },
  message: {
    textAlign: 'center',
    paddingBottom: 10,
  },
  camera: {
    flex: 1,
  },
  buttonContainer: {
    flex: 1,
    flexDirection: 'row',
    backgroundColor: 'transparent',
    marginBottom: 30,
    gap:20
  },
  button: {
    flex: 1,
    alignSelf: 'flex-end',
    alignItems: 'center',
  },
  text: {
    fontWeight: 'bold',
    color: 'white',
    textAlign: 'center'
  },
});