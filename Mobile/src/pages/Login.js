import React, { Component } from "react";
import { View, Text, TextInput, TouchableOpacity, StyleSheet, ImageBackground, AsyncStorage } from "react-native";

import apiDeslogado from "../services/apiDeslogado";

class Login extends Component {
    static navigationOptions = {
        header: null
    };

    constructor(props) {
        super(props);

        this.state = {
            email: "",
            senha: "",
            mensagem: ""
        }
    }

    efetuarLogin = async () => {
        try {
            const resposta = await apiDeslogado.post("/Login", {
                email: this.state.email,
                senha: this.state.senha
            });

            if (resposta.status === 200) {
                const token = resposta.data.token;
                await AsyncStorage.setItem("UsuarioToken", token);
                this.setState({ mensagem: "Login efetuado com sucesso!" })
                this.props.navigation.navigate("MenuNavigator");
            }
        }
        catch (erro) {
            this.setState({ mensagem: "Email ou senha inválidos!" })
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
                            onChangeText={email => this.setState({ email })}
                        />

                        <TextInput
                            style={styles.inputLogin}
                            placeholder="Senha"
                            placeholderTextColor="white"
                            password="true"
                            onChangeText={senha => this.setState({ senha })}
                        />

                        <TouchableOpacity
                            style={styles.buttonLogin}
                            onPress={this.efetuarLogin}
                        >
                            <Text style={styles.buttonLoginText}>Entrar</Text>
                        </TouchableOpacity>
                    </View>

                    <View style={styles.cadastroMensagem}>
                        <Text style={styles.cadastroMensagemText}>{this.state.mensagem}</Text>
                    </View>
                </View>
            </ImageBackground>
        )
    }
}

const styles = StyleSheet.create({
    overlay: {
        ...StyleSheet.absoluteFillObject,
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
        fontSize: 35,
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
    },
    cadastroMensagem: {
        marginTop: 15,
    },
    cadastroMensagemText: {
        color: "white"
    }
})

export default Login;