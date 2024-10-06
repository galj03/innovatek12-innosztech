# Introduction

Notes2Quiz is an education-themed mobile application which lets you create quizzes from your notes. Just take pictures of your notebook, upload a pdf, or even write a custom text to access the most fun way to learn.

First, upload the notes. The quiz will be generated, and you can take it almost instantly. After you finished with the quiz, tap on submit, and your results will be shown along with the correct answers for each question.

The convenience in this app is that not only can you optimize your learning via a dopamine-filled method, but in a way that is the most fitting to your habits. For example, if you want to study in a way that you repeat as many quizzes as possible, and remember the answers, you can. But if writing all the notes once again is your main approach, you can take a picture of them, or type them is straightaway.

## Getting Started

### Installation process

0. Prerequisites:
    - An OpenAI API key
    - Visual Studio
    - Visual Studio Code

1. Clone the repository from the following link:

        https://github.com/galj03/innovatek12-innosztech.git

2. Open the solution under src/ with Visual Studio. **'ASP.NET and web development'** and **'.NET desktop development'** are the two main modules that need to be installed via **Visual Studio Installer**.

3. Add <code>Config/ApplicationSettings.json</code> under the *'src/Notes2Quiz.BL.Impl'* folder, with the following data:

        {
        "ApiKey": "Your OpenAI API key",
        "Secret": "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING"
        }

4. After the dependencies are loaded, run the API project on ***http***. It will start listening on port 8080, so make sure it is free, or assign it to another port in <code>Notes2Quiz.Web.API/Properties/launchSettings.json</code>.

5. Install **Android Studio**, as its executable, *adb* will be required for running the UI. After opening Android Studio for the first time, the dependencies will be loaded, and the path <code>{your-appData-location}\AppData\Local\Android\Sdk\platform-tools</code> must be added to the *Path* environment variable.

6. Open the Notes2Quiz project in **Visual Studio Code**. Navigate the terminal to "src/Notes2Quiz.App.UI/notes2quizRaw/". Run <code>npm install</code> to build the UI dependencies. Then hit <code>npm start</code>, and you have already set everything on your machine. Time for your mobile device.

7. Download the **Expo Go** app from *App Store*/*Google Play*. Enter the app, and scan the QR code which was generated after the UI project started running. And you will get redirected to the application itself.

## Future development

Here are some features that we would like to implement in the future:

- support multiple languages (over 100 languages)
- select how many questions do we want
- add a new question type, where there can be more than one possible answers
- store previous quizzes and their results in a file or database
- implement authentication and authorization so that the user will only reach their own data
