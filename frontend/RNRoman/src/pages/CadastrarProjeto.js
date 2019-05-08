import React, { Component } from "react";

import { View, Text, StyleSheet, ScrollView, TextInput, TouchableOpacity, } from "react-native";
import api from "../services/api";

class CadastrarProjetos extends Component {
    constructor(props) {
        super(props);
        
        this.state = {
            titulo: "",
            idTema: "",
            descricao: ""
        }
    }

    _cadastrarProjeto = async () => {
        const respota = await api.post("/Projeto", {
            titulo: this.state.titulo,
            idTema: this.state.idTema,
            descricao: this.state.descricao,
            idprofessor: 1
        });

        const status = respota.status;
        console.warn(status);
    }

    render() {
        return (
            <ScrollView style={styles.projetosContainer}>
                <View style={styles.projetosHeader}>
                    <Text style={styles.projetosHeaderTitulo}>{"Projetos".toLocaleUpperCase()}</Text>
                </View>
                <View style={styles.projetosMain}>
                    <View style={styles.mainCadastro}>
                        <Text style={styles.mainCadastroTitulo}>Cadastrar Projeto</Text>
                        <View style={styles.mainCadastroLinha}>
                        </View>
                        <TextInput
                            style={styles.inputCadastro}
                            placeholder="Titulo"
                            placeholderTextColor="#808080"
                            onChangeText={titulo => this.setState({titulo})}
                        />
                        <TextInput
                            style={styles.inputCadastro}
                            placeholder="IdTema"
                            placeholderTextColor="#808080"
                            onChangeText={idTema => this.setState({idTema})}
                        />
                        <TextInput
                            style={styles.inputCadastroDescricao}
                            multiline={true}
                            numberOfLines={4}
                            placeholder="Descrição"
                            placeholderTextColor="#808080"
                            onChangeText={descricao => this.setState({descricao})}
                        />
                        <TouchableOpacity
                            style={styles.buttonLogin}
                            onPress={this._cadastrarProjeto}
                        >
                            <Text style={styles.buttonLoginText}>Cadastrar</Text>
                        </TouchableOpacity>
                    </View>
                </View>
            </ScrollView>
        )
    }
}

const styles = StyleSheet.create({
    projetosHeader: {
        width: "100%",
        height: 50,
        backgroundColor: "#0dadff",
        justifyContent: "center",
        alignItems: "center",
    },
    projetosHeaderTitulo: {
        color: "white",
        fontSize: 25,
    },

    projetosMain: {
        width: "100%",
        justifyContent: "center",
        alignItems: "center",
        marginTop: 20,
    },

    mainCadastro: {
        width: "100%",
        alignItems: "center",
    },
    mainCadastroTitulo: {
        color: "#696969",
        fontSize: 25,
    },
    mainCadastroLinha: {
        width: "70%",
        height: 1,
        backgroundColor: "rgba(13, 173, 255, 0.5)",
        marginBottom: 25,
    },  

    inputCadastro: {
        width: "80%",
        borderColor: "rgba(13, 173, 255, 0.3)",
        backgroundColor: "rgba(180, 206, 232, 0.1)",
        borderWidth: 0.9,
        borderRadius: 15,
        marginBottom: 15,
        color: "#808080",
        fontSize: 16,
        height: 50,
        paddingLeft: 10,
        paddingRight: 10,
    },

    inputCadastroDescricao: {
        width: "80%",
        height: 150,
        justifyContent: "flex-start",
        borderColor: "rgba(13, 173, 255, 0.3)",
        backgroundColor: "rgba(180, 206, 232, 0.1)",
        borderWidth: 0.9,
        borderRadius: 15,
        marginBottom: 15,
        color: "#808080",
        fontSize: 16,
        paddingLeft: 10,
        paddingRight: 10,
        textAlign: "center",
    },

    buttonLogin: {
        borderRadius: 20,
        backgroundColor: "#0dadff",
        marginTop: 15,
        padding: 7,
        paddingLeft: 17,
        paddingRight: 17
    },
    buttonLoginText: {
        fontSize: 16,
        color: "white"
    }
})

export default CadastrarProjetos;