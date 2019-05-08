import React, { Component } from "react";

import { View, ScrollView, Text, TextInput, TouchableOpacity, StyleSheet } from "react-native";

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
        )
    }
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        width: "100%",
        height: "100%",
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "rgba(13, 173, 255, 0.8)"
    },
    header: {
        marginBottom: 50
    },
    headerTitulo: {
        color: "white",
        fontSize: 30
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