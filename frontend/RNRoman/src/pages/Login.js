import React, { Component } from "react";

import { View, ScrollView, Text, TextInput, TouchableOpacity, StyleSheet, ImageBackground } from "react-native";

class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            email: "",
            senha: "",
        }
    }

    render() {
        return (
            <ImageBackground
                source={require("../assents/img/login-720-min.jpg")}
                style={StyleSheet.absoluteFillObject}
            >
                <View style={styles.overlay} />
                <View style={styles.main}>
                    <View style={styles.header}>
                        <Text style={styles.headerTitulo}>{"Roman".toLocaleUpperCase()}</Text>
                    </View>
                    <View style={styles.mainLogin}>
                        <Text style={styles.mainLoginTitulo}>Login</Text>
                        <TextInput
                            style={styles.inputLogin}
                            placeholder="Email"
                            placeholderTextColor="white"
                        />
                        <TextInput
                            style={styles.inputLogin}
                            placeholder="Senha"
                            placeholderTextColor="white"
                            password="true"
                        />
                        <TouchableOpacity
                            style={styles.buttonLogin}
                        >
                            <Text style={styles.buttonLoginText}>Entrar</Text>
                        </TouchableOpacity>
                    </View>
                </View>
            </ImageBackground>
        )
    }
}

const styles = StyleSheet.create({
    overlay: {
        ...StyleSheet.absoluteFillObject,
        // backgroundColor: "rgba(13, 173, 255, 0.7)"
        backgroundColor: "rgba(0, 0, 205, 0.6)"
    },
    main: {
        flex: 1,
        width: "100%",
        height: "100%",
        justifyContent: "center",
        alignItems: "center",
    },
    header: {
        marginBottom: 50
    },
    headerTitulo: {
        color: "white",
        fontSize: 30,
        fontFamily: "monospaced"
    },
    mainLogin: {
        width: "100%",
        alignItems: "center",
    },
    mainLoginTitulo: {
        color: "white",
        fontSize: 25,
        marginBottom: 17,
    },
    inputLogin: {
        width: "80%",
        borderBottomColor: "white",
        borderBottomWidth: 0.9,
        marginBottom: 10,
        padding: 1,
        color: "white",
        fontSize: 16
    },
    buttonLogin: {
        borderRadius: 20,
        backgroundColor: "white",
        marginTop: 15,
        padding: 7,
        paddingLeft: 17,
        paddingRight: 17
    },
    buttonLoginText: {
        fontSize: 16
    }
})

export default Login;